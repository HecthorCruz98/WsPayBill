using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Status.Commands.UpdateStates;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTransactionCommandHandler> _logger;

        public UpdateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateTransactionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Transaction>().GetFirstOrDefaultAsync(x => x.trnId == request.trnId);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.bilId = request.bilId;
                VerifiData.usrId = request.usrId;
                VerifiData.modifyDate = DateTime.Now;
                VerifiData.modifyUser = request.modifyUser;

                var EntityGetResponse = await _unitOfWork.Repository<Transaction>().UpdateAsync(VerifiData);

                _logger.LogInformation($"La transaccion {request.trnId} fue actualizada");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La Transaccion {request.trnId} no fue actualizada");

                return resp = false;
            }
        }
    }
}
