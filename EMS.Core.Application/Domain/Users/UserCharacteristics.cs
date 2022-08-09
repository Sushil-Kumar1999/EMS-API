using EMS.Core.Application.Domain.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Users
{
    public class UserCharacteristics : BaseEntity
    {
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; } // cm
        public double Weight { get; set; } // Kgs
    }
}
