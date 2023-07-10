using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Status.Commands.CreateStates;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Transactions.Commands.CreateTransactions
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTransactionCommandHandler> _logger;

        public CreateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateTransactionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Transaction>().GetFirstOrDefaultAsync(x => x.trnId == request.trnId);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Transaction>(request);
                var EntityAdd = await _unitOfWork.Repository<Transaction>().AddAsync(Entity);
                var childReportEntityResponse = _mapper.Map<Transaction>(EntityAdd);

                _logger.LogInformation($"La transaccion fue creada con el id {EntityAdd.trnId}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La transaccion {request.trnId} no fue creada");

                return resp = false;
            }
        }
    }
}
