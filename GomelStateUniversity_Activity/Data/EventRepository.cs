using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class EventRepository : IEventRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task CreateEventAsync(IFormCollection form)
        {
            var subdivisionName = form["Subdivision"].ToString();
            Event newEvent = new Event(form, db.Subdivisions.FirstOrDefault(x => x.Name == subdivisionName ));
            db.Events.Add(newEvent);
            await db.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventToDelete = db.Events.FirstOrDefault(x => x.Id == id);
            db.Events.Remove(eventToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<Event> GetEventAsync(int id)
        {
            return await db.Events.Include(x => x.Subdivision)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Event> GetEventAsync(string name)
        {
            return await db.Events.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await db.Events
                .OrderByDescending(x => x.DateTime)
                .Include(x => x.Subdivision)
                .Include(x => x.EventUsers)
                .ThenInclude(s => s.ApplicationUser)
                .ToListAsync();
        }
        public async Task<IEnumerable<Event>> GetMyEventsAsync(string userId)
        {
            return await db.Events
                .Where(x => x.DateTime > DateTime.Now)
                .Include(c => c.EventUsers)
                .ThenInclude(s => s.ApplicationUser)
                .Where(x => x.EventUsers.Any(c => c.ApplicationUser.Id == userId))
                .OrderByDescending(x => x.DateTime).ToListAsync();
        }
        public async Task<IEnumerable<Event>> GetEventsBySubdivisionAsync(int subdivisionId)
        {
            return await db.Events
                .Include(c => c.Subdivision)
                .Include(x => x.EventUsers)
                .ThenInclude(s => s.ApplicationUser)
                .Where(c => c.Subdivision.Id == subdivisionId)
                .OrderByDescending(x => x.DateTime).ToListAsync();
        }

        public async Task UpdateEventAsync(IFormCollection form)
        {

            var subdivisionName = form["Subdivision"].ToString();
            var eventId = int.Parse(form["Event.Id"]);
            var eventToUpdate = db.Events.FirstOrDefault(x => x.Id == eventId);
            var subdivision = db.Subdivisions.FirstOrDefault(x => x.Name == subdivisionName);
            eventToUpdate.UpdateEvent(form, subdivision);
            db.Entry(eventToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

    }
}
