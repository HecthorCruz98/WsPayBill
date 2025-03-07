using WebAppPayBill.Models;

namespace WebAppPayBill.Services.State
{
    public interface IStateService
    {
        Task<List<StateModel>> GetStates(int? Id);
        Task<bool> AddState(StateModel obj);
        Task<bool> UpState(StateModel obj);
    }
}
