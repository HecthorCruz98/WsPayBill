using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.Roles.Commands.UpdateRoles
{
    public class UpdateRolCommand : IRequest<bool>
    {
        public int rolId { get; set; }
        public string rolName { get; set; }
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }
    }
}
