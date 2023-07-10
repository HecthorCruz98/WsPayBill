using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.EnterpriseTypes.Commands.CreateEnterpriseTypes
{
    public class CreateEnterpriseTypeCommand : IRequest<bool>
    {
        public int etyId { get; set; }
        public string etyName { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
    }
}
