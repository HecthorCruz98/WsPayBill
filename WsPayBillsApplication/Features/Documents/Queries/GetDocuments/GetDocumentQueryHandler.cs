using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Bills.Queries.GetBill;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;
using WsPayBillsApplication.Models.BillsVm.GetDocuments;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Documents.Queries.GetDocuments
{
    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, List<DocumentsVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetDocumentQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetDocumentQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetDocumentQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<DocumentsVm>> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            if (request.DocId != null)
            {
                var entity = await _unitOfWork.Repository<Document>().GetAsync(x => x.docId == request.DocId);
                var entityVm = _mapper.Map<List<DocumentsVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Document>().GetAllAsync();
                var entityVm = _mapper.Map<List<DocumentsVm>>(entity);

                return entityVm;

            }
        }
    }
}
