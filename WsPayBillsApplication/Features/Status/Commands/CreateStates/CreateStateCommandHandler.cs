using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Roles.Commands.CreateRoles;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Status.Commands.CreateStates
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateStateCommandHandler> _logger;

        public CreateStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateStateCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<State>().GetFirstOrDefaultAsync(x => x.staId == request.staId);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<State>(request);
                var EntityAdd = await _unitOfWork.Repository<State>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<State>(EntityAdd);

                _logger.LogInformation($"El estado fue creado con el id {EntityAdd.staId}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El estado {request.staId} no fue creado");

                return resp = false;
            }
        }
    }
}
