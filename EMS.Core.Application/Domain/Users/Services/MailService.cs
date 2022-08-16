using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Users.Services
{
    public class MailService : IMailService
    {
        public IConfiguration Configuration { get; private set; }
        private readonly string _username;
        private readonly string _password;
        private readonly string _smtpHost;
        private readonly int _port;
        private readonly string _senderAddress;
        private readonly string _senderName;

        public MailService(IConfiguration configuration)
        {
            Configuration = configuration;
            _username = Configuration["EmailConfig:Username"];
            _password = Configuration["EmailConfig:Password"];
            _smtpHost = Configuration["EmailConfig:SMTPHost"];
            _port = int.Parse(Configuration["EmailConfig:Port"]);
            _senderAddress = Configuration["EmailConfig:SenderAddress"];
            _senderName = Configuration["EmailConfig:SenderName"];
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(_senderName, _senderAddress);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(toEmail, toEmail);
            message.To.Add(to);

            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = content;
            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();
            client.Connect(_smtpHost, _port, false);
            client.Authenticate(_username, _password);
            await client.SendAsync(message);
            client.Disconnect(true);
            client.Dispose();
        }

        public async Task SendEmailAsync(IEnumerable<string> recipientEmails, string subject, string content)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(_senderName, _senderAddress);
            message.From.Add(from);

            InternetAddressList list = new InternetAddressList();
            foreach (string email in recipientEmails)
            {
                list.Add(new MailboxAddress(email, email));
            }
            message.To.AddRange(list);

            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = content;
            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect(_smtpHost, _port, false);
            client.Authenticate(_username, _password);
            await client.SendAsync(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
