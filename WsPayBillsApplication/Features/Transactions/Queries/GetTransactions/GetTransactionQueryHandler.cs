using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Status.Queries.GetStates;
using WsPayBillsApplication.Models.BillsVm.GetStateVm;
using WsPayBillsApplication.Models.BillsVm.GetTransactionVm;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, List<TransactionVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetTransactionQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetTransactionQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetTransactionQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<TransactionVm>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            if (request.TrnId != null)
            {
                var entity = await _unitOfWork.Repository<Transaction>().GetAsync(x => x.trnId == request.TrnId);
                var entityVm = _mapper.Map<List<TransactionVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Transaction>().GetAllAsync();
                var entityVm = _mapper.Map<List<TransactionVm>>(entity);

                return entityVm;

            }
        }
    }
}
