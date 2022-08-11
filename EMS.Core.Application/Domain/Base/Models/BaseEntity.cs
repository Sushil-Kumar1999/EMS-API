using System;

namespace EMS.Core.Application.Domain.Base.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public int Status { get; set; } = 1;
        public DateTime CreatedDateUtc { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDateUtc { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedDateUtc { get; set; }
    }
}
