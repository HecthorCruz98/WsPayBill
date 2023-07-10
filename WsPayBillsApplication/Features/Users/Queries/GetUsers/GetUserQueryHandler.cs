using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Transactions.Queries.GetTransactions;
using WsPayBillsApplication.Models.BillsVm.GetTransactionVm;
using WsPayBillsApplication.Models.BillsVm.GetUserVm;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Users.Queries.GetUsers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<UserVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetUserQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetUserQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<UserVm>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            if (request.UsrId != null)
            {
                var entity = await _unitOfWork.Repository<User>().GetAsync(x => x.usrId == request.UsrId);
                var entityVm = _mapper.Map<List<UserVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<User>().GetAllAsync();
                var entityVm = _mapper.Map<List<UserVm>>(entity);

                return entityVm;

            }
        }
    }
}
