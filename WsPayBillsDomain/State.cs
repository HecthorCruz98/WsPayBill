using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain.Common;

namespace WsPayBillsDomain
{
    public class State : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int staId { get; set; }
        public string staName { get; set; }

    }
}
