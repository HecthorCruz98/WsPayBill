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
    public class Transaction : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int trnId { get; set; }
        public int usrId { get; set;}
        [ForeignKey("usrId")]
        public User User { get; set; }
        public int bilId { get; set; }
        [ForeignKey("bilId")]
        public Bill Bill { get; set; }

    }
}
