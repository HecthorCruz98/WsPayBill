using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain;

namespace WsPayBillsApplication.Models.BillsVm.GetTransactionVm
{
    public class TransactionVm
    {
        public int trnId { get; set; }
        public int usrId { get; set; }
        public int bilId { get; set; }
        public DateTime createDate { get; set;}
        public string createUser { get; set;}
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }
    }
}
