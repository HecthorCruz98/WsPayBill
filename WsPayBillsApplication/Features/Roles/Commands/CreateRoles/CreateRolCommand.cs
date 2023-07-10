using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.Roles.Commands.CreateRoles
{
    public class CreateRolCommand : IRequest<bool>
    {
        public int rolId { get; set; }
        public string rolName { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
    }
}
