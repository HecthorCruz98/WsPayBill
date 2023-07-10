using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Users.Commands.CreateUsers
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string usrName { get; set; }
        public string usrLastName { get; set; }
        public string usrAddres { get; set; }
        public string usrEmail { get; set; }
        public string usrCelPhone { get; set; }
        public int rolId { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }


    }
}
