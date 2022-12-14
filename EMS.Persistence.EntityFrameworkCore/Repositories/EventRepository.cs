using EMS.Core.Application.Domain.Events;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Persistence.EntityFrameworkCore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Persistence.EntityFrameworkCore.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(EMSDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Event>> GetAllByIds(IEnumerable<long> eventIds)
        {
            return await _dbSet.Where(x => eventIds.Contains(x.Id))
                               .AsNoTracking()
                               .ToListAsync();
        }

        public override async Task<IEnumerable<Event>> ListAsync()
        {
            return await _dbSet.Where(x => x.Status == 1)
                                .AsNoTracking()
                                .ToListAsync();
        }
    }
}
