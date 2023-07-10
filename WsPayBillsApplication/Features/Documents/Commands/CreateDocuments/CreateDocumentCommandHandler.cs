using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Bills.Commands.UpdateBill;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Documents.Commands.CreateDocuments
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDocumentCommandHandler> _logger;

        public CreateDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateDocumentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Document>().GetFirstOrDefaultAsync(x => x.docUrl == request.docUrl);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Document>(request);
                var EntityAdd = await _unitOfWork.Repository<Document>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<Document>(EntityAdd);

                _logger.LogInformation($"El documento fue creado con el id {EntityAdd.docId}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El documento {request.bilId} no fue creado");

                return resp = false;
            }
        }
    }
}
