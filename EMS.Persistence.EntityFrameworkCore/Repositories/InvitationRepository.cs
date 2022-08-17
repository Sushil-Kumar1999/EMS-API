using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Invitations;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Persistence.EntityFrameworkCore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Persistence.EntityFrameworkCore.Repositories
{
    public class InvitationRepository : GenericRepository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(EMSDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Invitation>> FindByEventIdAsync(long eventId, InvitationStatus status = 0)
        {
            return await _dbSet.Where(inv => inv.EventId == eventId)
                               .Where(inv => inv.InvitationStatus == status && status != 0)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Invitation>> FindByVolunteerIdAsync(string volunteerId, InvitationStatus status = 0)
        {
            return await _dbSet.Where(inv => inv.VolunteerId == volunteerId)
                               .Where(inv => inv.InvitationStatus == status && status != 0)
                               .ToListAsync();
        }
    }
}
