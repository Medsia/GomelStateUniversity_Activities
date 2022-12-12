using GomelStateUniversity_Activity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface IEventUserRepository
    {
        public Task SubscribeUserAsync(int EventId, string userId);
        public Task UnSubscribeUserAsync(int EventId, string userId);
        public Task SubscribeUserGroupAsync(int EventId, string userId, int amount);
        public Task SubscribeUserOnExhibitionAsync(int EventId, string userId);
        public Task SubscribeUserGroupOnExhibitionAsync(int EventId, string userId, int amount);
        public Task<IEnumerable<EventUser>> GetEventUsersByEventId(int EventId);
        public Task UnSubscribeUserFromExhibitionAsync(int EventId, string userId);

    }
}
