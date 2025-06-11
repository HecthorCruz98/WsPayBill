using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Models.BillsVm.GetRolVm;

namespace WsPayBillsApplication.Features.Roles.Queries.GetRol
{
    public class GetRolQuery : IRequest<List<RolVm>>
    {
        public GetRolQuery(int? rolId)
        {
            RolId = rolId;
        }
        public int? RolId { get; set; }
    }
}
