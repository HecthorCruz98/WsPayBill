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

namespace WsPayBillsApplication.Features.Enterprises.Commands.UpdateEnterprises
{
    public class UpdateEnterpriseCommandHandler : IRequestHandler<UpdateEnterpriseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEnterpriseCommandHandler> _logger;

        public UpdateEnterpriseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateEnterpriseCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Enterprise>().GetFirstOrDefaultAsync(x => x.entId == request.entId);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.entName = request.entName;
                VerifiData.etyId = request.etyId;
                VerifiData.State = request.State;
                VerifiData.modifyDate = DateTime.Now;
                VerifiData.modifyUser = request.createUser;

                var EntityGetResponse = await _unitOfWork.Repository<Enterprise>().UpdateAsync(VerifiData);

                _logger.LogInformation($"La empresa {request.entName} fue actualizada");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La empresa {request.entName} no fue actualizada");

                return resp = false;
            }
        }
    }
}
