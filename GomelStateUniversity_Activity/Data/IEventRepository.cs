using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface IEventRepository
    {
        public Task<IEnumerable<Event>> GetEventsAsync();
        public Task<IEnumerable<Event>> GetMyEventsAsync(string userId);
        public Task<Event> GetEventAsync(int id);
        public Task CreateEventAsync(IFormCollection form);
        public Task UpdateEventAsync(IFormCollection form);
        public Task DeleteEventAsync(int id);

    }
}
