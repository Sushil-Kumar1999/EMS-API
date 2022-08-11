using EMS.Core.Application.Domain.Events;
using EMS.Core.Application.Infrastructure.CalenderEventGenerator;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System.Text;

namespace EMS.Calendaring.iCal
{
    public class CalenderEventGenerator : ICalenderEventGenerator
    {
        public byte[] GenerateCalenderEventFile(Event @event)
        {
            var calendar = new Calendar();
            calendar.AddTimeZone(new VTimeZone("Europe/London"));

            var icalEvent = new CalendarEvent
            {
                Summary = "Title of event",
                Description = "Description for event",
                Start = new CalDateTime(@event.StartDate),
                End = new CalDateTime(@event.EndDate)
            };

            calendar.Events.Add(icalEvent);

            var iCalSerializer = new CalendarSerializer();
            string result = iCalSerializer.SerializeToString(calendar);

            return Encoding.ASCII.GetBytes(result);
        }
    }
}
