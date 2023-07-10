using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Enterprises.Commands.UpdateEnterprises;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.EnterpriseTypes.Commands.CreateEnterpriseTypes
{
    public class CreateEnterpriseTypeCommandHandler : IRequestHandler<CreateEnterpriseTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEnterpriseTypeCommandHandler> _logger;

        public CreateEnterpriseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEnterpriseTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateEnterpriseTypeCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<EnterpriseType>().GetFirstOrDefaultAsync(x => x.etyId == request.etyId);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<EnterpriseType>(request);
                var EntityAdd = await _unitOfWork.Repository<EnterpriseType>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<EnterpriseType>(EntityAdd);

                _logger.LogInformation($"El tipo de empresa fue creada con el id {EntityAdd.etyId}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El tipo de empresa {request.etyId} no fue creada");

                return resp = false;
            }
        }
    }
}
