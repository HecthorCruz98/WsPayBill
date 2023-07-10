using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Roles.Commands.CreateRoles;
using WsPayBillsApplication.Features.Roles.Commands.UpdateRoles;
using WsPayBillsApplication.Features.Status.Queries.GetStates;
using WsPayBillsApplication.Features.Transactions.Commands.CreateTransactions;
using WsPayBillsApplication.Features.Transactions.Commands.UpdateTransaction;
using WsPayBillsApplication.Features.Transactions.Queries.GetTransactions;
using WsPayBillsApplication.Models.BillsVm.GetRolVm;
using WsPayBillsApplication.Models.BillsVm.GetTransactionVm;

namespace WsPayBillsCoreAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TransactionController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<TransactionController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public TransactionController(ILogger<TransactionController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetTransactions")]
        public async Task<ActionResult<IEnumerable<TransactionVm>>> GetTransaction(int? trnId)
        {
            var query = await _mediator.Send(new GetTransactionQuery(trnId));
            return Ok(query);
        }

        [HttpPost("CreateTransaction")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateTransactionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateTransaction")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateTransaction([FromBody] UpdateTransactionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
