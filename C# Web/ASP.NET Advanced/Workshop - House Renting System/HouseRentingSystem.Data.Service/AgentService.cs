using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Data.Service.Interfaces;
using HouseRentingSystem.ViewModels.Agent;
using Microsoft.EntityFrameworkCore;
using System;


namespace HouseRentingSystem.Data.Service
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext dbContext;

        public AgentService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgentExistById(string userId)
        {
            var result = await dbContext.Agents.AnyAsync(a => a.UserId.ToString() == userId);
            return result;
        }

        public async Task<bool> AgentExistByPhone(string phone)
        {
            var result = await dbContext.Agents.AnyAsync(a => a.PhoneNumber == phone);
            return result;
        }

        public Task Create(string userId, BecomeAgentFormModel model)
        {
           var agent = new Agent()
           {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            dbContext.Agents.Add(agent);
            return dbContext.SaveChangesAsync();
        }

        public async Task<bool> HasRentsByUserId(string userId)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return false;
            }

            return user.RentedHouses.Any();
        }
    }
}
