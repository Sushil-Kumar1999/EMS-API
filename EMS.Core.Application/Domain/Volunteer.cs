using EMS.Core.Application.Domain.Base.Models;
using EMS.Core.Application.Domain.Users;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain
{
    public class Volunteer : BaseEntity
    {
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public long Age { get; set; } // years
        public double Height { get; set; } // cm
        public double Weight { get; set; } // Kgs
        public ICollection<EventVolunteer> EventsAttended { get; set; }
    }
}
