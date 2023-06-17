using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homies.ViewModels.ViewModels;

namespace Homies.Service.Intefraces
{
	public interface IEventService
	{
		Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();

        Task<IEnumerable<JoinEventViewModel>> GetMyEventsAsync(string userId);

        Task AddEventAsync(AddEventViewModel model, string id);

		Task<AddEventViewModel> GetEventViewModelsAsync();

		Task<JoinEventViewModel?> GetEventByIdAsync(int id, string userId);

		Task AddMeToEventAsync(string userId, JoinEventViewModel model);

		Task LeaveEventAsync( string userId, JoinEventViewModel model);
    }
}
