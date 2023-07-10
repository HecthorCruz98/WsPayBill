using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsDomain.Common
{
    public abstract class Entity
    {
        public DateTime? createDate { get; set; }
        public DateTime? modifyDate { get; set; }
        public string? createUser { get; set; }
        public string? modifyUser { get; set; }

    }
}
