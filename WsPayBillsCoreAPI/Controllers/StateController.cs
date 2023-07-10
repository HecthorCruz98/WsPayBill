using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Roles.Commands.CreateRoles;
using WsPayBillsApplication.Features.Roles.Commands.UpdateRoles;
using WsPayBillsApplication.Features.Roles.Queries.GetRol;
using WsPayBillsApplication.Features.Status.Commands.CreateStates;
using WsPayBillsApplication.Features.Status.Commands.UpdateStates;
using WsPayBillsApplication.Features.Status.Queries.GetStates;
using WsPayBillsApplication.Models.BillsVm.GetRolVm;
using WsPayBillsApplication.Models.BillsVm.GetStateVm;

namespace WsPayBillsCoreAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class StateController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<StateController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public StateController(ILogger<StateController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetState")]
        public async Task<ActionResult<IEnumerable<StateVm>>> GetState(int? staId)
        {
            var query = await _mediator.Send(new GetStateQuery(staId));
            return Ok(query);
        }

        [HttpPost("CreateState")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateState([FromBody] CreateStateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateState")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateState([FromBody] UpdateStateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
