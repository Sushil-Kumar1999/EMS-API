namespace EMS.Core.Application.Domain
{
    public class EventVolunteer
    {
        public Event Event { get; set; }
        public Volunteer Volunteer { get; set; }
        public long EventId { get; set; }
        public long VolunteerId { get; set; }

        public EventVolunteer(Event @event, Volunteer volunteer)
        {
            Event = @event;
            Volunteer = volunteer;
        }

        public EventVolunteer()
        {

        }
    }
}
