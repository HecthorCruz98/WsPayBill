using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.Status.Commands.UpdateStates
{
    public class UpdateStateCommand : IRequest<bool>
    {
        public int staId { get; set; }
        public string staName { get; set; }
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }
    }
}
