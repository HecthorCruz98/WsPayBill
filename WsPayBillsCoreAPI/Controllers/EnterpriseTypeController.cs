using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Bills.Commands.CreateBill;
using WsPayBillsApplication.Features.Bills.Commands.UpdateBill;
using WsPayBillsApplication.Features.Bills.Queries.GetBill;
using WsPayBillsApplication.Features.Enterprises.Queries.GetEnterprises;
using WsPayBillsApplication.Features.EnterpriseTypes.Commands.CreateEnterpriseTypes;
using WsPayBillsApplication.Features.EnterpriseTypes.Commands.UpdateEnterpriseTypes;
using WsPayBillsApplication.Features.EnterpriseTypes.Queries.GetEnterpriseType;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;
using WsPayBillsApplication.Models.BillsVm.GetEnterpriseType;

namespace WsPayBillsCoreAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class EnterpriseTypeController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<EnterpriseTypeController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public EnterpriseTypeController(ILogger<EnterpriseTypeController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetEnterpriseTypes")]
        public async Task<ActionResult<IEnumerable<EnterpriseTypeVm>>> GetEnterpriseType(int? etyId)
        {
            var query = await _mediator.Send(new GetEnterpriseTypeQuery(etyId));
            return Ok(query);
        }

        [HttpPost("CreateEnterpriseType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEnterpriseType([FromBody] CreateEnterpriseTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateEnterpriseType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateEnterpriseType([FromBody] UpdateEnterpriseTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
