using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Models.BillsVm.GetEnterprise;

namespace WsPayBillsApplication.Features.Enterprises.Queries.GetEnterprises
{
    public class GetEnterpriseQuery : IRequest<List<EnterprisesVm>>
    {
        public GetEnterpriseQuery(int? entId)
        {
            entId = EntId;
        }
        public int? EntId { get; set; }
    }
}
