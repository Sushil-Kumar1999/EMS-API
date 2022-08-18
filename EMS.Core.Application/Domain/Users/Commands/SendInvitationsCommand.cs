using EMS.Core.DataTransfer.Invitations.DataContracts;
using EMS.Core.DataTransfer.Users.DataContracts;
using MediatR;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Users.Commands
{
    public class SendInvitationsCommand : IRequest<int>
    {
        public long EventId { get; }
        public IEnumerable<VolunteerDetailsDataContract> VolunteerDetails { get; set; }

        public SendInvitationsCommand(long eventId, IEnumerable<VolunteerDetailsDataContract> volunteerDetails)
        {
            EventId = eventId;
            VolunteerDetails = volunteerDetails;
        }
    }
}
