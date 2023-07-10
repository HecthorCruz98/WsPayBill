using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Enterprises.Commands.CreateEnterprises
{
    public class CreateEnterpriseCommand : IRequest<bool>
    {
        public int entId { get; set; }
        public string entName { get; set; }
        public int etyId { get; set; }
        public int State { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
    }
}
