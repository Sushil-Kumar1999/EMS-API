using System;

namespace EMS.Core.Application.Domain.Base.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public Guid UpdatedById { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime ModifiedDateUtc { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
    }
}
