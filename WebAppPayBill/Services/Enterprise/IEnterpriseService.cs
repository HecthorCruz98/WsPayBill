using WebAppPayBill.Models;

namespace WebAppPayBill.Services.Enterprise
{
    public interface IEnterpriseService
    {
        Task<List<EnterpriseModel>> GetEnterprises(int? Id);
        Task<bool> AddEnterprise(EnterpriseModel obj);
        Task<bool> UpEnterprise(EnterpriseModel obj);
        Task<EnterpriseModel> GetEnterprise(int Id);
       
        
    }
}
