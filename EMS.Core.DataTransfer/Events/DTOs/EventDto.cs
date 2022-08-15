using System;

namespace EMS.Core.DataTransfer.Events.DTOs
{
    public class EventDto
    {
        public long Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public EventDto(long id, string title, string description, string location, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            Description = description;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
