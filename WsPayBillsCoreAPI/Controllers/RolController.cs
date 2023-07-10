using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Enterprises.Queries.GetEnterprises;
using WsPayBillsApplication.Features.EnterpriseTypes.Commands.CreateEnterpriseTypes;
using WsPayBillsApplication.Features.EnterpriseTypes.Commands.UpdateEnterpriseTypes;
using WsPayBillsApplication.Features.Roles.Commands.CreateRoles;
using WsPayBillsApplication.Features.Roles.Commands.UpdateRoles;
using WsPayBillsApplication.Features.Roles.Queries.GetRol;
using WsPayBillsApplication.Models.BillsVm.GetEnterpriseType;
using WsPayBillsApplication.Models.BillsVm.GetRolVm;

namespace WsPayBillsCoreAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class RolController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<RolController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public RolController(ILogger<RolController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetRol")]
        public async Task<ActionResult<IEnumerable<RolVm>>> GetRol(int? rolId)
        {
            var query = await _mediator.Send(new GetRolQuery(rolId));
            return Ok(query);
        }

        [HttpPost("CreateRol")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateRol([FromBody] CreateRolCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateRol")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateRol([FromBody] UpdateRolCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
