using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Bills.Commands.CreateBill;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Bills.Commands.UpdateBill
{
    public class UpdateBillCommandHandler : IRequestHandler<UpdateBillCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBillCommandHandler> _logger;

        public UpdateBillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateBillCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateBillCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Bill>().GetFirstOrDefaultAsync(x => x.bilId == request.bilId && x.State == 1);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.bilName = request.bilName;
                VerifiData.bilDescription = request.bilDescription;
                VerifiData.bilNumber = request.bilNumber;
                VerifiData.bilContract = request.bilContract;
                VerifiData.bilValuePay = request.bilValuePay;
                VerifiData.State = request.State;
                VerifiData.modifyDate = DateTime.Now;
                VerifiData.modifyUser = request.updateUser;

                var EntityGetResponse = await _unitOfWork.Repository<Bill>().UpdateAsync(VerifiData);

                _logger.LogInformation($"La factura {request.bilId} fue actualizada");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La factura {request.bilId} no fue actualizada");

                return resp = false;
            }
        }
    }
}
