using EMS.Core.Application.Domain;
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

        public override async Task<IEnumerable<Event>> ListAsync()
        {
            return await _dbSet.Where(x => x.Status == 1)
                                .AsNoTracking()
                                .ToListAsync();
        }
    }
}
