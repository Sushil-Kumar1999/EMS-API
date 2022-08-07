using Microsoft.AspNetCore.Identity;
using System;

namespace EMS.Core.Application.Domain.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime ModifiedDateUtc { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public Guid UpdatedById { get; set; }
    }
}
