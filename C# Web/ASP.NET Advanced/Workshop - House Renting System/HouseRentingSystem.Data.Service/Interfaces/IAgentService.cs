using HouseRentingSystem.ViewModels.Agent;

namespace HouseRentingSystem.Data.Service.Interfaces
{
    public interface IAgentService
    {
        Task<bool> AgentExistById(string userId);

        Task<bool> AgentExistByPhone(string phone);

        Task<bool> HasRentsByUserId(string userId);

        Task Create(string userId, BecomeAgentFormModel model);
    }
}
