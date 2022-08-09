using EMS.Core.Application.Domain.Users;
using System.Threading.Tasks;

namespace EMS.Core.Application.Infrastructure.Security
{
    public interface ITokenManager
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);
    }
}
