using EMS.Core.Application.Domain.Enums;
using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;
using System.Collections.Generic;

namespace EMS.Core.Application.Domain.Users.Queries
{
    public class FindVolunteersInInvitationQuery : IRequest<IEnumerable<UserDto>>
    {
        public long EventId { get; set; }
        public InvitationStatus InvitationStatus { get; set; }

        public FindVolunteersInInvitationQuery(long eventId, InvitationStatus invitationStatus)
        {
            EventId = eventId;
            InvitationStatus = invitationStatus;
        }
    }
}
