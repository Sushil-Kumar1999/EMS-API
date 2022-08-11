using EMS.Core.Application.Domain.Users;
using EMS.Core.Application.Domain.Users.Services;
using EMS.Core.Application.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Security.Jwt
{
    public class SecurityManager : ISecurityManager
    {
        private readonly IMailService _mailService;
        private readonly IConfiguration Configuration;

        public SecurityManager(IMailService mailService, IConfiguration configuration)
        {
            _mailService = mailService;
            Configuration = configuration;
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
                    .Replace("{{Password}}", tempPassword)
                    .Replace("{{LoginUrl}}", $"{Configuration["WebAppUrl"]}/login");

                await _mailService.SendEmailAsync(applicationUser.Email, "Welcome to EMS", content);
            }
        }
    }
}
