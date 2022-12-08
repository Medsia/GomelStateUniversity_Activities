using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Notifications
{
    public interface INotificationService
    {
        public Task SendAsync(string recepientEmail, string messageSubject, string messageText);
    }
}
