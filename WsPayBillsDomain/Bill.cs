using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain.Common;

namespace WsPayBillsDomain
{
    public class Bill : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bilId { get; set; }
        public string bilName { get; set; }
        public string bilDescription { get; set; }
        public int bilNumber { get; set; }
        public int bilContract { get; set; }
        public float bilValuePay { get; set; }
        public int State { get; set; }
        [ForeignKey("State")]
        public State States { get; set; }
    }
}
