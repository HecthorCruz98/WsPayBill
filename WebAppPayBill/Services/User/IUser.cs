using WebAppPayBill.Models;

namespace WebAppPayBill.Services.User
{
    public interface IUser
    {
        Task<List<BillModel>> GetBills(int? Id);
        Task<bool> AddBill(BillModel obj);
        Task<bool> UpBill(BillModel obj);
    }
}
