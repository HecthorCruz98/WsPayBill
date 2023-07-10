using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Bills.Commands.CreateBill;
using WsPayBillsApplication.Features.Bills.Commands.UpdateBill;
using WsPayBillsApplication.Features.Bills.Queries.GetBill;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;

namespace WsPayBillsCoreAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class BillController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<BillController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public BillController(ILogger<BillController> logger,IConfiguration configuration,IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetBills")]
        public async Task<ActionResult<IEnumerable<BillsVm>>> GetBills(int? BillNumber, int? BillContract, string? BillName)
        {
            var query = await _mediator.Send(new GetBillQuery(BillNumber,BillContract,BillName));
            return Ok(query);
        }

        [HttpPost("CreateBill")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateBill([FromBody] CreateBillCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateBill")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateBill([FromBody] UpdateBillCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
