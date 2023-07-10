using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Models.BillsVm.GetBillsVm;

namespace WsPayBillsApplication.Features.Bills.Queries.GetBill
{
    public class GetBillQuery : IRequest<List<BillsVm>>
    {
        public GetBillQuery(int? bilNumber, int? bilContract, string? bilName)
        {
            BilNumber = bilNumber;
            BilContract = bilContract;
            BilName = bilName;
        }
        public int? BilNumber { get; set; }
        public int? BilContract { get; set; }
        public string? BilName { get; set; }


    }
}
