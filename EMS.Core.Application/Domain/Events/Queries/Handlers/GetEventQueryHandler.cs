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
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventDto>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventDto> Handle(GetEventQuery query, CancellationToken cancellationToken)
        {
            Event @event = await _eventRepository.GetByIdAsync(query.EventId);

            return new EventDto(@event.Id, @event.Title, @event.Description,
                                @event.Location, @event.StartDate, @event.EndDate);
        }
    }
}
