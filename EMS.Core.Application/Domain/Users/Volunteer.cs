using System;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Users
{
    public class Volunteer : ApplicationUser
    {
        public DateTime DateOfBirth { get; set; } // years
        public double Height { get; set; } // cm
        public double Weight { get; set; } // Kgs
        // events attended by volunteer
        public ICollection<Event> Events { get; set; }
    }
}
