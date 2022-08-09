using EMS.Core.Application.Domain.Base.Models;
using EMS.Core.Application.Domain.Users;
using System;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // volunteers selected for event
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}
