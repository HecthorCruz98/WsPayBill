using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.Status.Commands.CreateStates
{
    public class CreateStateCommand : IRequest<bool>
    {
        public int staId { get; set; }
        public string staName { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
    }
}
