using MediatR;

namespace EMS.Core.Application.Domain.Invitations.Commands
{
    public class UpdateInvitationCommand : IRequest<long>
    {
        public long EventId { get; set; }

        public string VolunteerId { get; set; }
        public string VolunteerEmail { get; set; }
        public bool Response { get; set; }

        public UpdateInvitationCommand(long eventId, string volunteerId, string volunteerEmail, bool response)
        {
            EventId = eventId;
            VolunteerId = volunteerId;
            VolunteerEmail = volunteerEmail;
            Response = response;
        }
    }
}
