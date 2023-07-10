using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Models.BillsVm.GetEnterpriseType
{
    public class EnterpriseTypeVm
    {
        public int etyId { get; set; }
        public string etyName { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }
    }
}
