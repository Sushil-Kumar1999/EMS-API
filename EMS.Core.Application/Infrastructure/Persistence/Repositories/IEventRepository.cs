using EMS.Core.Application.Domain.Events;

namespace EMS.Core.Application.Infrastructure.Persistence.Repositories
{
    public interface IEventRepository : IGenericRepository<Event>
    {
    }
}
