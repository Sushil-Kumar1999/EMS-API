using EMS.Core.Application.Domain.Base.Models;
using System;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Users
{
    public class Volunteer : BaseEntity
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public long Age { get; set; } // years
        public double Height { get; set; } // cm
        public double Weight { get; set; } // Kgs
        // events attended by volunteer
        public ICollection<Event> Events { get; set; } 
    }
}
