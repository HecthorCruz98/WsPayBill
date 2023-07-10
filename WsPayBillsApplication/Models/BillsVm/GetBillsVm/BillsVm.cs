using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Models.BillsVm.GetBillsVm
{
    public class BillsVm
    {
        public int bilId { get; set; }
        public string bilName { get; set; }
        public string bilDescription { get; set; }
        public int bilNumber { get; set; }
        public int bilContract { get; set; }
        public decimal bilValuePay { get; set; }
        public int State { get; set; }
        public string createUser { get; set; }
        public string updateUser { get; set; }
    }
}
