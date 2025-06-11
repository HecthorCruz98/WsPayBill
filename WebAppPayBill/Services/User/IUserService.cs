using WebAppPayBill.Models;

namespace WebAppPayBill.Services.User
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers(int? Id);

        Task<UserModel> GetUser(int Id);
        Task<bool> AddUser(UserModel obj);
        Task<bool> UpUser(UserModel obj);
    }
}
