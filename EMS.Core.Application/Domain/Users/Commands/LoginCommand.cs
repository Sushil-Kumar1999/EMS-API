using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;

namespace EMS.Core.Application.Domain.Users.Commands
{
    public class LoginCommand : IRequest<LoginResponseDto>
    {
        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; }
        public string Password { get; }
    }
}
