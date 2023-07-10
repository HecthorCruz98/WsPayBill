using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Models.BillsVm.GetUserVm
{
    public class UserVm
    {
        public int usrId { get; set; }
        public string usrName { get; set; }
        public string usrLastName { get; set; }
        public string usrAddres { get; set; }
        public string usrEmail { get; set; }
        public string usrCelPhone { get; set; }
        public int rolId { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }
    }
}
