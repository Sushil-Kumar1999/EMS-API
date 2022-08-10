using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
