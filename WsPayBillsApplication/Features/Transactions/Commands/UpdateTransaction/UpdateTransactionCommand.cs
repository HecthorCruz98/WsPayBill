using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : IRequest<bool>
    {
        public int trnId { get; set; }
        public int usrId { get; set; }
        public int bilId { get; set; }
        public DateTime modifyDate { get; set; }
        public string modifyUser { get; set; }
    }
}
