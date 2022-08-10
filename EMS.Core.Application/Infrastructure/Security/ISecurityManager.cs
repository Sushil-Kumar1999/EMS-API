using EMS.Core.Application.Domain.Users;
using System.Threading.Tasks;

namespace EMS.Core.Application.Infrastructure.Security
{
    public interface ISecurityManager
    {
        Task SendConfirmationEmailAsync(ApplicationUser applicationUser, string tempPassword);
    }
}
