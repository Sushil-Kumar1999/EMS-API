using System;

namespace EMS.Core.DataTransfer.Users.DTOs
{
    public class VolunteerDto : UserDto
    {
        public DateTime DateOfBirth { get; }
        public double Height { get; }
        public double Weight { get; }

        public VolunteerDto(string id, string username, string firstName, string lastName, string email,
                                string role, DateTime dateOfBirth, double height, double weight)
                                : base(id, username,  firstName,  lastName,  email, role)
        {
            DateOfBirth = dateOfBirth;
            Height = height;
            Weight = weight;
        }
    }
}
