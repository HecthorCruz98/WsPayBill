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

namespace WsPayBillsApplication.Features.Documents.Commands.UpdateDocuments
{
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDocumentCommandHandler> _logger;

        public UpdateDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateDocumentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Document>().GetFirstOrDefaultAsync(x => x.docId == request.docId);

            bool resp = false;

            if (VerifiData != null)
            {
                VerifiData.usrId = request.usrId;
                VerifiData.bilId = request.bilId;
                VerifiData.docUrl = request.docUrl;
                VerifiData.modifyDate = DateTime.Now;
                VerifiData.modifyUser = request.modifyUser;

                var EntityGetResponse = await _unitOfWork.Repository<Document>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El documento {request.bilId} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El documento {request.bilId} no fue actualizado");

                return resp = false;
            }
        }
    }
}
