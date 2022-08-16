using EMS.Core.Application.Domain.Users;
using EMS.Core.Application.Domain.Users.QueryObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Core.Application.Infrastructure.Persistence.Repositories
{
    public interface IVolunteerRepository : IGenericRepository<Volunteer>
    {
        Task<IEnumerable<Volunteer>> FindAsync(FilterVolunteersQueryObject query);
    }
}
