using System;

namespace EMS.Core.DataTransfer.Users.DTOs
{
    public class EventDto
    {
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public EventDto(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
