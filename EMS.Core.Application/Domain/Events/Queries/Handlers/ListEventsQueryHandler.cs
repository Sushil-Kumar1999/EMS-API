using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Core.DataTransfer.Events.DTOs;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Core.Application.Domain.Events.Queries.Handlers
{
    public class ListEventsQueryHandler : IRequestHandler<ListEventsQuery, IEnumerable<EventDto>>
    {
        private readonly IEventRepository _eventRepository;

        public ListEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<EventDto>> Handle(ListEventsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Event> events = await _eventRepository.ListAsync();

            IEnumerable<EventDto> eventDtos = events.Select(e => new EventDto(e.Id, e.Title, e.Description,
                                                        e.Location, e.StartDate, e.EndDate));

            return eventDtos;
        }
    }
}
