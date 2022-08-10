using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EMS.Core.Application.Domain.Users.Services
{
    public class MailService : IMailService
    {
        public IConfiguration Configuration { get; private set; }

        public MailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            string username = Configuration["EmailConfig:Username"];
            string password = Configuration["EmailConfig:Password"];
            string smtpHost = Configuration["EmailConfig:SMTPHost"];
            int port = int.Parse(Configuration["EmailConfig:Port"]);
            string senderAddress = Configuration["EmailConfig:SenderAddress"];
            string senderName = Configuration["EmailConfig:SenderName"];

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(senderName, senderAddress);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(toEmail, toEmail);
            message.To.Add(to);

            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = content;
            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();
            client.Connect(smtpHost, port, false);
            client.Authenticate(username, password);
            await client.SendAsync(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
