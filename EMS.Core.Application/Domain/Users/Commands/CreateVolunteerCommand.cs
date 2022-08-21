using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using System;

namespace EMS.Core.Application.Domain.Users.Commands
{
    public class CreateVolunteerCommand : IRequest<UserRegistrationResponseDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public CreateVolunteerCommand(string firstName, string lastName, string email, DateTime dateOfBirth, double height, double weight)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Height = height;
            Weight = weight;
        }
    }
}
