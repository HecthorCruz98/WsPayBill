using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Bills.Commands.CreateBill;
using WsPayBillsApplication.Features.Bills.Commands.UpdateBill;
using WsPayBillsApplication.Features.Bills.Queries.GetBill;
using WsPayBillsApplication.Features.Enterprises.Commands.CreateEnterprises;
using WsPayBillsApplication.Features.Enterprises.Commands.UpdateEnterprises;
using WsPayBillsApplication.Features.Enterprises.Queries.GetEnterprises;
using WsPayBillsApplication.Features.EnterpriseTypes.Queries.GetEnterpriseType;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;
using WsPayBillsApplication.Models.BillsVm.GetEnterprise;

namespace WsPayBillsCoreAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class EnterpriseController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<EnterpriseController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public EnterpriseController(ILogger<EnterpriseController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetEnterprises")]
        public async Task<ActionResult<IEnumerable<EnterprisesVm>>> GetEnterprise(int? entId)
        {
            var query = await _mediator.Send(new GetEnterpriseQuery(entId));
            return Ok(query);
        }

        [HttpPost("CreateEnterprise")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEnterprise([FromBody] CreateEnterpriseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateEnterprise")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateEnterprise([FromBody] UpdateEnterpriseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
