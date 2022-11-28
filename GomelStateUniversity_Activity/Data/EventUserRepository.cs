using GomelStateUniversity_Activity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class EventUserRepository : IEventUserRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task SubscribeUserAsync(int eventId, string userId)
        {
            var eventToUpdate = db.Events.Find(eventId);
            if (eventToUpdate.TicketsCount <= 0)
            {
                throw new InvalidOperationException("Кол-во билетов превышает допустимое количество");
            }

            EventUser eventUser = new EventUser(eventId, userId);
            db.EventUsers.Add(eventUser);           
            
            eventToUpdate.TicketsCount--;
            db.Entry(eventToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        public async Task UnSubscribeUserAsync(int eventId, string userId)
        {
            var eventToUpdate = db.Events.Find(eventId);
            var eventUser = db.EventUsers.Find(eventId, userId);
            try
            {
                if (eventToUpdate == null || eventUser == null)
                    throw new InvalidOperationException("Вы не записаны");

                db.EventUsers.Remove(eventUser);
                eventToUpdate.TicketsCount += eventUser.Tickets;
                db.Entry(eventToUpdate).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }         

        }
        public async Task SubscribeUserGroupAsync(int eventId, string userId, int amount)
        {
            var eventToUpdate = db.Events.Find(eventId);
            if(eventToUpdate.TicketsCount < amount)
            {
                throw new InvalidOperationException("Кол-во билетов превышает допустимое количество");
            }         
            
            EventUser eventUser = new EventUser(eventId, userId, amount);
            db.EventUsers.Add(eventUser);
            eventToUpdate.TicketsCount -= amount;
            db.Entry(eventToUpdate).State = EntityState.Modified;
            

            await db.SaveChangesAsync();
        }

    }
}
