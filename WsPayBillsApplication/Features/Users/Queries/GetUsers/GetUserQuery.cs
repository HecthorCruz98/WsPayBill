using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Models.BillsVm.GetUserVm;

namespace WsPayBillsApplication.Features.Users.Queries.GetUsers
{
    public class GetUserQuery : IRequest<List<UserVm>>
    {
        public GetUserQuery(int? usrId)
        {
            UsrId = usrId;
        }
        public int? UsrId { get; set; }
    }
}
