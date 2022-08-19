using EMS.Core.Application.Domain.Invitations;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.DataTransfer.Events.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Events.Queries.Handlers
{
    public class FindEventsInInvitationQueryHandler : IRequestHandler<FindEventsInInvitationQuery, IEnumerable<EventDto>>
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IEventRepository _eventRepository;

        public FindEventsInInvitationQueryHandler(IInvitationRepository invitationRepository, IEventRepository eventRepository)
        {
            _invitationRepository = invitationRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<EventDto>> Handle(FindEventsInInvitationQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Invitation> invitations = await _invitationRepository
                .FindByVolunteerIdAsync(query.VolunteerId, query.InvitationStatus);

            IEnumerable<long> eventIds = invitations.Select(x => x.EventId);
            IEnumerable<Event> events = await _eventRepository.GetAllByIds(eventIds);

            return events.Select(e => new EventDto(e.Id, e.Title, e.Description, e.Location,
                                                   e.StartDate, e.EndDate));
        }
    }
}
