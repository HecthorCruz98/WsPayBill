using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.EnterpriseTypes.Commands.UpdateEnterpriseTypes
{
    public class UpdateEnterpriseTypeCommand : IRequest<bool>
    {
        public int etyId { get; set; }
        public string etyName { get; set; }
        public DateTime modifyDate { get; set; } 
        public string modifyUser { get; set; }
    }
}
