using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.Bills.Commands.UpdateBill
{
    public class UpdateBillCommand : IRequest<bool>
    {
        public int bilId { get; set; }
        public string bilName { get; set; }
        public string bilDescription { get; set; }
        public int bilNumber { get; set; }
        public int bilContract { get; set; }
        public float bilValuePay { get; set; }
        public int State { get; set; }
        public DateTime updateDate { get; set; }
        public string updateUser { get; set; }
    }
}
