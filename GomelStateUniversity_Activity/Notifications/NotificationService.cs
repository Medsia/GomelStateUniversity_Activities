using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Notifications
{
    public class NotificationService : INotificationService
    {
        private object smtpClient;

        public Task SendAsync(string recepientEmail, string messageSubject, string messageText)
        {
            SendDebug(recepientEmail, messageSubject, messageText);

            Send(recepientEmail, messageSubject, messageText);

            return Task.CompletedTask;

        }

        private void SendDebug(string recepientEmail, string messageSubject, string messageText)
        {
            Debug.WriteLine($"Получатель: {recepientEmail}");
            Debug.WriteLine($"Тема: {messageSubject}");
            Debug.WriteLine($"Сообщение: {messageText}");
        }

        private void Send(string recepientEmail, string messageSubject, string messageText)
        {

            using (var smtpClient = new SmtpClient("smtp.mail.ru", 587))
            {

                //var message = new MailMessage("gsu_activities@mail.ru", recepientEmail);
                var message = new MailMessage("gsu_activities@mail.ru", "Medsia@mail.ru");

                message.Subject = messageSubject;

                message.Body = messageText;

                smtpClient.Credentials = new NetworkCredential("gsu_activities@mail.ru", "uBJ3Y3Y1XZWnwEzBx3sM");
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }
        }
    }
}
