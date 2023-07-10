using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Bills.Queries.GetBill
{
    public class GetBillQueryHandler : IRequestHandler<GetBillQuery, List<BillsVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetBillQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetBillQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetBillQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<BillsVm>> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            if (request.BilNumber != null)
            {
                var entity = await _unitOfWork.Repository<Bill>().GetAsync(x => x.bilNumber == request.BilNumber);
                var entityVm = _mapper.Map<List<BillsVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Bill>().GetAllAsync();
                var entityVm = _mapper.Map<List<BillsVm>>(entity);

                return entityVm;

            }

        }
    }
}
