using WebAppPayBill.Models;

namespace WebAppPayBill.Services
{
    public interface IBillService
    {
        Task<List<BillModel>> GetBills(int? Id);
        Task<BillModel> GetBill(int Id);
        Task<bool> AddBill(BillModel obj);
        Task<bool> UpBill(BillModel obj);

    }
}
