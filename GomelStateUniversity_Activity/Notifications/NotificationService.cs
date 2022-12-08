using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Notifications
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(string recepientEmail, string messageSubject, string messageText)
        {
            Send(recepientEmail, messageSubject, messageText);

            return Task.CompletedTask;

        }

        private void Send(string recepientEmail, string messageSubject, string messageText)
        {
            Debug.WriteLine($"Получатель: {recepientEmail}");
            Debug.WriteLine($"Тема: {messageSubject}");
            Debug.WriteLine($"Сообщение: {messageText}");
        }
    }
}
