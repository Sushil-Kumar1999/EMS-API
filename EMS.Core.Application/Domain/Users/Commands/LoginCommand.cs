using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;

namespace EMS.Core.Application.Domain.Users.Commands
{
    public class LoginCommand : IRequest<LoginResponseDto>
    {
        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public string Email { get; }
        public string Password { get; }
    }
}
