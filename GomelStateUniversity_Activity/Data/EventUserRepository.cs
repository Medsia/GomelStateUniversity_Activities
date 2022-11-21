using GomelStateUniversity_Activity.Models;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class EventUserRepository : IEventUserRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task SubscribeUserAsync(int EventId, string userId)
        {
            EventUser eventUser = new EventUser(EventId, userId);
            db.EventUsers.Add(eventUser);
            await db.SaveChangesAsync();
        }
        public async Task UnSubscribeUserAsync(int EventId, string userId)
        {
            EventUser eventUser = new EventUser(EventId, userId);

            db.EventUsers.Remove(eventUser);
            await db.SaveChangesAsync();

        }
        public async Task SubscribeUserGroupAsync(int EventId, string userId, int amount)
        {

            EventUser eventUser = new EventUser(EventId, userId, amount);
            db.EventUsers.Add(eventUser);

            await db.SaveChangesAsync();
        }

    }
}
