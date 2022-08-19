using EMS.Core.DataTransfer.Users.DTOs;
using MediatR;

namespace EMS.Core.Application.Domain.Users.Queries
{
    public class GetVolunteerQuery : IRequest<VolunteerDto>
    {
        public string VolunteerId { get; set; }

        public GetVolunteerQuery(string volunteerId)
        {
            VolunteerId = volunteerId;
        }
    }
}
