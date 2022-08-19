using EMS.Core.Application.Domain.Enums;
using EMS.Core.DataTransfer.Events.DTOs;
using MediatR;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Events.Queries
{
    public class FindEventsInInvitationQuery : IRequest<IEnumerable<EventDto>>
    {
        public string VolunteerId { get; set; }
        public InvitationStatus InvitationStatus { get; set; }

        public FindEventsInInvitationQuery(string volunteerId, InvitationStatus invitationStatus)
        {
            VolunteerId = volunteerId;
            InvitationStatus = invitationStatus;
        }
    }
}
