using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.DataTransfer.Invitations.DataContracts
{
    public class RespondToInvitationDataContract
    {
        public long EventId { get; set; }

        public string VolunteerId { get; set; }
        public string VolunteerEmail { get; set; }
        public bool Response { get; set; }
    }
}
