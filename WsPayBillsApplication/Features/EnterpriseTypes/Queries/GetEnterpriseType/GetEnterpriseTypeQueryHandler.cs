using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Enterprises.Queries.GetEnterprises;
using WsPayBillsApplication.Models.BillsVm.GetEnterprise;
using WsPayBillsApplication.Models.BillsVm.GetEnterpriseType;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.EnterpriseTypes.Queries.GetEnterpriseType
{
    public class GetEnterpriseTypeQueryHandler : IRequestHandler<GetEnterpriseTypeQuery, List<EnterpriseTypeVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetEnterpriseTypeQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetEnterpriseTypeQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetEnterpriseTypeQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<EnterpriseTypeVm>> Handle(GetEnterpriseTypeQuery request, CancellationToken cancellationToken)
        {
            if (request.EtyId != null)
            {
                var entity = await _unitOfWork.Repository<EnterpriseType>().GetAsync(x => x.etyId == request.EtyId);
                var entityVm = _mapper.Map<List<EnterpriseTypeVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<EnterpriseType>().GetAllAsync();
                var entityVm = _mapper.Map<List<EnterpriseTypeVm>>(entity);

                return entityVm;

            }
        }
    }
}
