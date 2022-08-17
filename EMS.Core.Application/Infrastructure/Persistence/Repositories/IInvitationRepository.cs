using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Invitations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Core.Application.Infrastructure.Persistence.Repositories
{
    public interface IInvitationRepository : IGenericRepository<Invitation>
    {
        Task<IEnumerable<Invitation>> FindByEventIdAsync(long eventId, InvitationStatus status = 0);
        Task<IEnumerable<Invitation>> FindByVolunteerIdAsync(string volunteerId, InvitationStatus status = 0);
    }
}
