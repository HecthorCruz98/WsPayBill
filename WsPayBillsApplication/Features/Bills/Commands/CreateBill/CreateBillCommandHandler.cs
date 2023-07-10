using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Bills.Commands.CreateBill
{
    public class CreateBillCommandHandler : IRequestHandler<CreateBillCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateBillCommandHandler> _logger;

        public CreateBillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateBillCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Bill>().GetFirstOrDefaultAsync(x => x.bilId == request.bilId && x.State == 1);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Bill>(request);
                var EntityAdd = await _unitOfWork.Repository<Bill>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<Bill>(EntityAdd);

                _logger.LogInformation($"La factura fue creada con el id {EntityAdd.bilId}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La factura {request.bilId} no fue creada");

                return resp = false;
            }
        }
    }
}
