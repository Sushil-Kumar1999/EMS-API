using EMS.Core.Application.Domain.Base.Models;
using EMS.Core.Application.Domain.Enums;

namespace EMS.Core.Application.Domain.Invitations
{
    public class Invitation : BaseEntity
    {
        public long EventId { get; set; }
        public string VolunteerId { get; set; }
        public InvitationStatus InvitationStatus { get; set; }
    }
}
