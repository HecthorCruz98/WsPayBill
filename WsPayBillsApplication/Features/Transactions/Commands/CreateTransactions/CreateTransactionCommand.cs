using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsPayBillsApplication.Features.Transactions.Commands.CreateTransactions
{
    public class CreateTransactionCommand : IRequest<bool>
    {
        public int trnId { get; set; }
        public int usrId { get; set; }
        public int bilId { get; set; }
        public DateTime createDate { get; set; }
        public string createUser { get; set; }

    }
}
