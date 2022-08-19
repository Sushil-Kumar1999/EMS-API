using EMS.Core.Application.Domain.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Core.Application.Infrastructure.Persistence.Repositories
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<IEnumerable<Event>> GetAllByIds(IEnumerable<long> eventIds);
    }
}
