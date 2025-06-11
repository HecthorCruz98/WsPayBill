using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsApplication.Models.BillsVm.GetTransactionVm;

namespace WsPayBillsApplication.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionQuery : IRequest<List<TransactionVm>>
    {
        public GetTransactionQuery(int? trnId)
        {
            TrnId = trnId;
        }
        public int? TrnId { get; set; }
    }
}
