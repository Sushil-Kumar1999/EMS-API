using MediatR;
using System;

namespace EMS.Core.Application.Domain.Events.Commands
{
    public class UpdateEventCommand : IRequest<long>
    {
        public long EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public UpdateEventCommand(long eventId, string title, string description,
            string location, DateTime startDate, DateTime endDate)
        {
            EventId = eventId;
            Title = title;
            Description = description;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
