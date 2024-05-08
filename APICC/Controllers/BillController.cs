using EDCCC.Application.Features.Bills.Commands.CreateBills;
using EDCCC.Application.Features.Bills.Queries.GetBillsList;
using EDCCC.Application.Features.Bills.Queries.GetBillsListByCCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APICC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Name = "GetBills")]
        [ProducesResponseType(typeof(IEnumerable<BillVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BillVm>>> GetTBills()
        {
            var query = new GetBillsListQuery();
            var bills = await _mediator.Send(query);

            return Ok(bills);
        }


        [HttpGet("{creditCardId}", Name = "GetBillsListByCCard")]
        [ProducesResponseType(typeof(IEnumerable<BillVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BillVm>>> GetTransactionsByTypeAndCreditCard(int CCardId)
        {
            var query = new GetBillsListByCCardQuery(CCardId);
            var bills = await _mediator.Send(query);

            return Ok(bills);
        }

        [HttpPost(Name = "CreateBills")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateBillsCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
