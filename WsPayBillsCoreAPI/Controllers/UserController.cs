using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Status.Queries.GetStates;
using WsPayBillsApplication.Features.Transactions.Commands.CreateTransactions;
using WsPayBillsApplication.Features.Transactions.Commands.UpdateTransaction;
using WsPayBillsApplication.Features.Users.Commands.CreateUsers;
using WsPayBillsApplication.Features.Users.Commands.UpdateUsers;
using WsPayBillsApplication.Features.Users.Queries.GetUsers;
using WsPayBillsApplication.Models.BillsVm.GetRolVm;
using WsPayBillsApplication.Models.BillsVm.GetUserVm;

namespace WsPayBillsCoreAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(ILogger<UserController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<UserVm>>> GetUsers(int? usrId)
        {
            var query = await _mediator.Send(new GetUserQuery(usrId));
            return Ok(query);
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateTransaction([FromBody] UpdateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
