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
                Summary = @event.Title,
                Description = "Description for event",
                DtStart = new CalDateTime(@event.StartDate),
                DtEnd = new CalDateTime(@event.EndDate)
            };

            calendar.Events.Add(icalEvent);

            var iCalSerializer = new CalendarSerializer();
            string result = iCalSerializer.SerializeToString(calendar);
            //    return File(Encoding.ASCII.GetBytes(result), "text/calendar", "calendar.ics");
            return Encoding.ASCII.GetBytes(result);
        }
    }
}
