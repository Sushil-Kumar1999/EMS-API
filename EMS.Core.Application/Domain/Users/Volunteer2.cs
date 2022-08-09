using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users
{
    class Volunteer2 : ApplicationUser
    {
        public DateTime DateOfBirth { get; set; } // years
        public double Height { get; set; } // cm
        public double Weight { get; set; } // Kgs
        // events attended by volunteer
        public ICollection<Event> Events { get; set; }
    }
}
