using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.EnterpriseTypes.Commands.CreateEnterpriseTypes;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Roles.Commands.CreateRoles
{
    public class CreateRolCommandHandler : IRequestHandler<CreateRolCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRolCommandHandler> _logger;

        public CreateRolCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateRolCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Rol>().GetFirstOrDefaultAsync(x => x.rolId == request.rolId);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Rol>(request);
                var EntityAdd = await _unitOfWork.Repository<Rol>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<Rol>(EntityAdd);

                _logger.LogInformation($"El rol fue creado con el id {EntityAdd.rolId}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El rol {request.rolId} no fue creado");

                return resp = false;
            }
        }
    }
}
