using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data.Service.Interfaces
{
    public interface IAgentService
    {
        public Task<bool> AgentExistById(string userId);
    }
}
