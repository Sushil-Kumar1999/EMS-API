using EMS.Core.Application.Domain.Users;
using EMS.Core.Application.Domain.Users.Services;
using EMS.Core.Application.Infrastructure.Security;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Security.Jwt
{
    public class SecurityManager : ISecurityManager
    {
        private readonly IMailService _mailService;

        public SecurityManager(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task SendConfirmationEmailAsync(ApplicationUser applicationUser, string tempPassword)
        {
            var assembly = Assembly.GetEntryAssembly();
            var resourceStream = assembly.GetManifestResourceStream("EMS.Api.EmailTemplates.welcome-email-template.html");

            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                string emailTemplate = await reader.ReadToEndAsync();
                string content = emailTemplate
                    .Replace("{{FirstName}}", applicationUser.FirstName)
                    .Replace("{{LastName}}", applicationUser.LastName)
                    .Replace("{{Email}}", applicationUser.Email)
                    .Replace("{{Password}}", tempPassword);

                await _mailService.SendEmailAsync(applicationUser.Email, "Welcome to EMS", content);
            }
        }
    }
}
