using EMS.Core.Application.Domain.Base.Models;
using EMS.Core.Application.Domain.Users;
using System;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Events
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // volunteers selected for event
        public Guid CreatedById { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
