using WebAppPayBill.Models;

namespace WebAppPayBill.Services.Transaction
{
    public interface ITransactionService
    {
        Task<List<TransactionModel>> GetTransactions(int? Id);
        Task<bool> AddTransaction(TransactionModel obj);
        Task<bool> UpTransaction(TransactionModel obj);
    }
}
