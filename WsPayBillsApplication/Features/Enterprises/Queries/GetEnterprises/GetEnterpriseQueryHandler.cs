using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Bills.Queries.GetBill;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;
using WsPayBillsApplication.Models.BillsVm.GetEnterprise;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Enterprises.Queries.GetEnterprises
{
    public class GetEnterpriseQueryHandler : IRequestHandler<GetEnterpriseQuery,List<EnterprisesVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetEnterpriseQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetEnterpriseQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetEnterpriseQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<EnterprisesVm>> Handle(GetEnterpriseQuery request, CancellationToken cancellationToken)
        {
            if (request.EntId != null)
            {
                var entity = await _unitOfWork.Repository<Enterprise>().GetAsync(x => x.entId == request.EntId);
                var entityVm = _mapper.Map<List<EnterprisesVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Enterprise>().GetAllAsync();
                var entityVm = _mapper.Map<List<EnterprisesVm>>(entity);

                return entityVm;

            }
        }
    }
}
