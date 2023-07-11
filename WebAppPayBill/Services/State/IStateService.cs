using WebAppPayBill.Models;

namespace WebAppPayBill.Services.State
{
    public interface IStateService
    {
        Task<List<StateModel>> GetStates(int? Id);
        Task<bool> AddStates(StateModel obj);
        Task<bool> UpStates(StateModel obj);
    }
}
