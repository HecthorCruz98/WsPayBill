using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Features.Bills.Commands.CreateBill
{
    public class CreateBillCommand : IRequest<bool>
    {
        public int bilId { get; set; }
        public string bilName { get; set; }
        public string bilDescription { get; set; }
        public int bilNumber { get; set; }
        public int bilContract { get; set; }
        public decimal bilValuePay { get; set; }
        public int State { get; set; }
        public string createUser { get; set; }
        public DateTime createDate { get; set; }

    }
}
