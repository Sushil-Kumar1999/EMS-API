using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;

namespace EMS.Core.Application.Domain.Users.Commands
{
    public class RegisterUserCommand : IRequest<UserRegistrationResponseDto>
    {
        public RegisterUserCommand(string firstName, string lastName, string email, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
