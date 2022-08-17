using System.Collections.Generic;

namespace EMS.Core.DataTransfer.Invitations.DataContracts
{
    public class SendInvitationRequestDataContract
    {
        public long EventId { get; set; }
        public IEnumerable<VolunteerDetailsDataContract> VolunteerDetails { get; set; }

    }

    public class VolunteerDetailsDataContract
    {
        public string VolunteerId { get; set; }
        public string VolunteerEmail { get; set; }
    }
}
