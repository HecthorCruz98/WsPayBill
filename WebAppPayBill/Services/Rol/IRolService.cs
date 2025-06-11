using WebAppPayBill.Models;

namespace WebAppPayBill.Services.Rol
{
    public interface IRolService
    {
        Task<List<RolModel>> GetRoles(int? Id);

        Task<RolModel> GetRol(int Id);
        Task<bool> AddRol(RolModel obj);
        Task<bool> UpRol(RolModel obj);
    }
}
