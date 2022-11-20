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
        public Task SubscribeUsersAsync(int EventId, IEnumerable<string> userId);
        public Task UnSubscribeUsersAsync(int EventId, IEnumerable<string> userId);
    }
}
