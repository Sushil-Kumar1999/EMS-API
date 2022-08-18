using EMS.Core.Application.Domain.Enums;
using EMS.Core.DataTransfer.Invitations.DataContracts;
using EMS.Core.DataTransfer.Users.DataContracts;
using MediatR;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Invitations.Commands
{
    public class UpdateInvitationCommand : IRequest<long>
    {
        public long EventId { get; set; }
        public IEnumerable<VolunteerDetailsDataContract> VolunteerDetails { get; set; }
        public InvitationStatus InvitationStatus { get; set; }

        public UpdateInvitationCommand(long eventId, IEnumerable<VolunteerDetailsDataContract> volunteerDetails, InvitationStatus invitationStatus)
        {
            EventId = eventId;
            VolunteerDetails = volunteerDetails;
            InvitationStatus = invitationStatus;
        }
    }
}
