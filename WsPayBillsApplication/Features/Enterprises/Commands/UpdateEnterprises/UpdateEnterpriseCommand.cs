using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.Enterprises.Commands.UpdateEnterprises
{
    public class UpdateEnterpriseCommand : IRequest<bool>
    {
        public int entId { get; set; }
        public string entName { get; set; }
        public int etyId { get; set; }
        public int State { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
    }
}
