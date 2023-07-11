using WebAppPayBill.Models;

namespace WebAppPayBill.Services.EnterpriseType
{
    public interface IEnterpriseTypeService
    {
        Task<List<EnterpriseTypeModel>> GetEnterpriseTypes(int? Id);
        Task<bool> AddEnterpriseType(EnterpriseTypeModel obj);
        Task<bool> UpEnterpriseType(EnterpriseTypeModel obj);
    }
}
