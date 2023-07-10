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
    public class Enterprise : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int entId { get; set; }
        public string entName { get; set; }
        public int etyId { get; set; }
        [ForeignKey("etyId")]
        public EnterpriseType EnterpriseType { get; set; }
        public int State { get; set; }
        [ForeignKey("State")]
        public State States { get; set; }
    }
}
