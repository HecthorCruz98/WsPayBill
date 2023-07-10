using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.EnterpriseTypes.Commands.UpdateEnterpriseTypes;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Roles.Commands.UpdateRoles
{
    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateRolCommandHandler> _logger;

        public UpdateRolCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateRolCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Rol>().GetFirstOrDefaultAsync(x => x.rolId == request.rolId);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.rolName = request.rolName;
                VerifiData.modifyDate = DateTime.Now;
                VerifiData.modifyUser = request.modifyUser;

                var EntityGetResponse = await _unitOfWork.Repository<Rol>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El rol {request.rolName} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El rol {request.rolName} no fue actualizado");

                return resp = false;
            }
        }
    }
}
