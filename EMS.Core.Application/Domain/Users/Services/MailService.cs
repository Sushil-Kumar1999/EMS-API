using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Services
{
    public class MailService : IMailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            // TODO Some values here should be provided via config.

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Hello World", "no-reply@ems.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(toEmail, toEmail);
            message.To.Add(to);

            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = content;
            message.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp-relay.sendinblue.com", 587, false);
            client.Authenticate("johnklutz.sk@gmail.com", "OC7b36sy4IzPrHKF");
            await client.SendAsync(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
