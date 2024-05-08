using EDCCC.Application.Features.Accounts.Commands.CreateAccounts;
using EDCCC.Application.Features.Accounts.Queries.GetAccountsList;
using EDCCC.Application.Features.Customer.Queries.GetCustomersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APICC.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAccount")]
        [ProducesResponseType(typeof(IEnumerable<AccountsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AccountsVm>>> GetAccount()
        {
            var query = new GetAccountsListQuery();
            var account = await _mediator.Send(query);
            return Ok(account);
        }

        [HttpPost(Name = "CreateAccounts")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAccounts([FromBody] CreateAccountsCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
