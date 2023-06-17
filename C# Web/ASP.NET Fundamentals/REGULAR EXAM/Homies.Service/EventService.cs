using Homies.Data;
using Homies.Data.Models;
using Homies.Service.Intefraces;
using Homies.ViewModels.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homies.Service
{
    public class EventService : IEventService
    {

        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddEventAsync(AddEventViewModel model, string id)
        {
            var eventModel = new Event
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = id

            };

            await dbContext.Events.AddAsync(eventModel);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddMeToEventAsync(string userId, JoinEventViewModel model)
        {
            var alreadyadded = await dbContext.EventsParticipants.AnyAsync(x => x.HelperId == userId || x.EventId == model.Id);

            if (!alreadyadded)
            {
                var newEvent = new EventParticipant
                {
                    EventId = model.Id,
                    HelperId = userId
                };

                await dbContext.EventsParticipants.AddAsync(newEvent);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await dbContext.Events.Select(x => new AllEventViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Start = x.Start.ToString("dd-MM-yyyy H:mm"),
                Type = x.Type.Name
            }).ToListAsync();
        }

        public async Task<JoinEventViewModel?> GetEventByIdAsync(int id, string userId)
        {
            return await dbContext.Events.Where(x => x.Id == id).Select(x => new JoinEventViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Start = x.Start.ToString("dd-MM-yyyy H-mm"),
                Type = x.Type.Name,
                Organiser = userId

            }).FirstOrDefaultAsync();
        }

        public async Task<AddEventViewModel> GetEventViewModelsAsync()
        {
            var types = await dbContext.Types.Select(x => new TypeViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            var eventModel = new AddEventViewModel
            {
                Types = types
            };

            return eventModel;
        }

        public async Task<IEnumerable<JoinEventViewModel>> GetMyEventsAsync(string userId)
        {
            return await dbContext.EventsParticipants.Where(x => x.HelperId == userId)
                .Select(x => new JoinEventViewModel
                {
                    Id = x.EventId,
                    Name = x.Event.Name,
                    Start = x.Event.Start.ToString("dd-MM-yyyy H:mm"),
                    Type = x.Event.Type.Name,
                    Organiser = x.Event.Organiser.UserName
                }).ToListAsync();
        }

       


       
    }
}

    




