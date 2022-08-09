using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;

namespace EMS.Core.Application.Domain.Users.Commands
{
    public class RegisterUserCommand : IRequest<UserRegistrationResponseDto>
    {
        public RegisterUserCommand(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
