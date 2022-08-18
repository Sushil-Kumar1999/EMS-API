using EMS.Core.DataTransfer.Events.DTOs;
using MediatR;

namespace EMS.Core.Application.Domain.Events.Queries
{
    public class GetEventQuery : IRequest<EventDto>
    {
        public long EventId { get; set; }

        public GetEventQuery(long eventId)
        {
            EventId = eventId;
        }
    }
}
