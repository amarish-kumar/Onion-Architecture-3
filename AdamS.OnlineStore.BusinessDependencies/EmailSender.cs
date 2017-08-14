using AdamS.OnlineStore.DomainModel;
using System.Net.Mail;
using AdamS.OnlineStore.BusinessInterfaces;

namespace AdamS.OnlineStore.BusinessDependencies
{
    public class EmailSender : INotificationProvider
    {
        public bool Send(string destination, string subject, string body)
        {
            const string @from = "admin@mycompany.com.au";
            const string mailServer = "mail.mycompany.com";
            const string mailServerUserName = "bob@mycompany.com";
            const string mailServerPassword = "p@ssw0rd";

            if (!destination.IsValidEmailAddress())
            {
                return false;
            }

            try
            {
                var email = new MailMessage(from, destination)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true

                };

                using (var client = new SmtpClient())
                {
                    client.Host = mailServer;
                    client.Port = 587;
                    client.EnableSsl = false;

                    client.Credentials = new System.Net.NetworkCredential(
                        mailServerUserName, mailServerPassword);
                    
                    //client.Send(email);
                }

                return true;

            }
            catch 
            {
                return false;
            }
        }
    }
}