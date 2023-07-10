using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Models.BillsVm.GetEnterpriseType;

namespace WsPayBillsApplication.Features.EnterpriseTypes.Queries.GetEnterpriseType
{
    public class GetEnterpriseTypeQuery : IRequest<List<EnterpriseTypeVm>>
    {
        public GetEnterpriseTypeQuery(int? etyId)
        {
            etyId = EtyId;
        }
        public int? EtyId { get; set; }
    }
}
