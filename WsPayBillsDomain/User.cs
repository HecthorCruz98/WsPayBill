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
    public class User : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int usrId { get; set; }
        public string usrName { get; set; }
        public string usrLastName{ get; set; }
        public string usrAddres { get; set; }
        public string usrEmail { get; set; }
        public string usrCelPhone { get; set; }
        public int rolId { get; set; }
        [ForeignKey("rolId")]
        public Rol Rol { get; set; }
    }
}
