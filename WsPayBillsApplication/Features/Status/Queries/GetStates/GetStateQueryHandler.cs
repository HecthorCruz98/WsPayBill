using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Contracts.Persistence;
using WsPayBillsApplication.Features.Roles.Queries.GetRoles;
using WsPayBillsApplication.Models.BillsVm.GetRolVm;
using WsPayBillsApplication.Models.BillsVm.GetStateVm;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Status.Queries.GetStates
{
    public class GetStateQueryHandler : IRequestHandler<GetStateQuery, List<StateVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetStateQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetStateQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetStateQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<StateVm>> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            if (request.StaId != null)
            {
                var entity = await _unitOfWork.Repository<State>().GetAsync(x => x.staId == request.StaId);
                var entityVm = _mapper.Map<List<StateVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<State>().GetAllAsync();
                var entityVm = _mapper.Map<List<StateVm>>(entity);

                return entityVm;

            }
        }
    }
}
