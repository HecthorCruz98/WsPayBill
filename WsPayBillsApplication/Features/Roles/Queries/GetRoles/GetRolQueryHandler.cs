using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.EnterpriseTypes.Queries.GetEnterpriseType;
using WsPayBillsApplication.Features.Roles.Queries.GetRol;
using WsPayBillsApplication.Models.BillsVm.GetEnterpriseType;
using WsPayBillsApplication.Models.BillsVm.GetRolVm;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Roles.Queries.GetRoles
{
    public class GetRolQueryHandler : IRequestHandler<GetRolQuery, List<RolVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetRolQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetRolQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetRolQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<RolVm>> Handle(GetRolQuery request, CancellationToken cancellationToken)
        {
            if (request.RolId != null)
            {
                var entity = await _unitOfWork.Repository<Rol>().GetAsync(x => x.rolId == request.RolId);
                var entityVm = _mapper.Map<List<RolVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Rol>().GetAllAsync();
                var entityVm = _mapper.Map<List<RolVm>>(entity);

                return entityVm;

            }
        }
    }
}
