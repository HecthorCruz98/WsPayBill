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

namespace WsPayBillsApplication.Features.Enterprises.Commands.CreateEnterprises
{
    public class CreateEnterpriseCommandHandler : IRequestHandler<CreateEnterpriseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEnterpriseCommandHandler> _logger;

        public CreateEnterpriseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEnterpriseCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Enterprise>().GetFirstOrDefaultAsync(x => x.entId == request.entId);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Enterprise>(request);
                var EntityAdd = await _unitOfWork.Repository<Enterprise>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<Enterprise>(EntityAdd);

                _logger.LogInformation($"La empresa fue creada con el id {EntityAdd.entId}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La empresa {request.entId} no fue creada");

                return resp = false;
            }
        }
    }
}
