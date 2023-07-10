using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Bills.Commands.CreateBill;
using WsPayBillsApplication.Features.Bills.Commands.UpdateBill;
using WsPayBillsApplication.Features.Bills.Queries.GetBill;
using WsPayBillsApplication.Features.Documents.Commands.CreateDocuments;
using WsPayBillsApplication.Features.Documents.Commands.UpdateDocuments;
using WsPayBillsApplication.Features.Documents.Queries.GetDocuments;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;
using WsPayBillsApplication.Models.BillsVm.GetDocuments;

namespace WsPayBillsCoreAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class DocumentController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<DocumentController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public DocumentController(ILogger<DocumentController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetDocuments")]
        public async Task<ActionResult<IEnumerable<DocumentsVm>>> GetDocuments(int? DocId)
        {
            var query = await _mediator.Send(new GetDocumentQuery(DocId));
            return Ok(query);
        }

        [HttpPost("CreateDocument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateDocument([FromBody] CreateDocumentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateDocument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateDocument([FromBody] UpdateDocumentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
