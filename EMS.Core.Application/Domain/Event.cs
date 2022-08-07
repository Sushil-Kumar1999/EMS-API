using EMS.Core.Application.Domain.Base.Models;
using System;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<EventVolunteer> SelectedVolunteers { get; set; }
    }
}
