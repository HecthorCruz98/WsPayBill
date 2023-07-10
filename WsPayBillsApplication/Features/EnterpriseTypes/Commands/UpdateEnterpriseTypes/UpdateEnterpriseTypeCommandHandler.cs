using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.EnterpriseTypes.Commands.UpdateEnterpriseTypes
{
    public class UpdateEnterpriseTypeCommandHandler : IRequestHandler<UpdateEnterpriseTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEnterpriseTypeCommandHandler> _logger;

        public UpdateEnterpriseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateEnterpriseTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateEnterpriseTypeCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<EnterpriseType>().GetFirstOrDefaultAsync(x => x.etyId == request.etyId);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.etyName = request.etyName;
                VerifiData.modifyDate = DateTime.Now;
                VerifiData.modifyUser = request.modifyUser;

                var EntityGetResponse = await _unitOfWork.Repository<EnterpriseType>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El tipo de empresa {request.etyName} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El tipo de empresa {request.etyName} no fue actualizado");

                return resp = false;
            }
        }
    }
}
