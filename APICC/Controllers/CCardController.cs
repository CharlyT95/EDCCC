using EDCCC.Application.Features.CCards.Command.CreateCCard;
using EDCCC.Application.Features.CCards.Command.UpdateCCard;
using EDCCC.Application.Features.CCards.Queries.GetCCardsList;
using EDCCC.Application.Features.Customer.Queries.GetCustomersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APICC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCCards")]
        [ProducesResponseType(typeof(IEnumerable<CCardsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CCardsVm>>> GetCCards()
        {
            var query = new GetCCardsListQuery();
            var ccard = await _mediator.Send(query);
            return Ok(ccard);
        }

        [HttpPost(Name = "CreateCCard")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCCard([FromBody] CreateCCardCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpPut(Name = "UpdateCCard")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCCard([FromBody] UpdateCCardCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
