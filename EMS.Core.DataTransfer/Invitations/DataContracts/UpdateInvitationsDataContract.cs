using EMS.Core.DataTransfer.Users.DataContracts;
using System.Collections.Generic;

namespace EMS.Core.DataTransfer.Invitations.DataContracts
{
    public class UpdateInvitationsDataContract
    {
        public long EventId { get; set; }
        public IEnumerable<VolunteerDetailsDataContract> VolunteerDetails { get; set; }
    }
}
