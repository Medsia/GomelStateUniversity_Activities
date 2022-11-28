using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Notifications
{
    interface INotificationService
    {
        Task SendConfirmationCodeAsync(string cellPhone, int code);
    }
}
