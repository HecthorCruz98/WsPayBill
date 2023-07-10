using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Roles.Commands.UpdateRoles;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Status.Commands.UpdateStates
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStateCommandHandler> _logger;

        public UpdateStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateStateCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<State>().GetFirstOrDefaultAsync(x => x.staId == request.staId);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.staName = request.staName;
                VerifiData.modifyDate = DateTime.Now;
                VerifiData.modifyUser = request.modifyUser;

                var EntityGetResponse = await _unitOfWork.Repository<State>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El estado {request.staName} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El estado {request.staName} no fue actualizado");

                return resp = false;
            }
        }
    }
}
