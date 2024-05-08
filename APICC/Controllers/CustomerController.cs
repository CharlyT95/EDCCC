using EDCCC.Application.Features.Customer.Commands.CreateCustomer;
using EDCCC.Application.Features.Customer.Queries.GetCustomersList;
using EDCCC.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APICC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Name}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(IEnumerable<CustomersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomersVm>>> GetCustomerByName(String Name)
        {
            var query = new GetCustomersListQuery(Name);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }

        [HttpPost("{Name}", Name = "CreateCustomer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
