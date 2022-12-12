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
        public Task<Event> GetEventAsync(string name);
        public Task CreateEventAsync(IFormCollection form, string imgPath);

        public Task CreateEventAsync(IFormCollection form, string imgPath, string description);
        public Task UpdateEventAsync(IFormCollection form, string imgPath);
        public Task DeleteEventAsync(int id);
        public Task<IEnumerable<Event>> GetEventsBySubdivisionAsync(int subdivisionId);
        public Task<IEnumerable<Event>> GetExhibitionsAsync();
    }
}
