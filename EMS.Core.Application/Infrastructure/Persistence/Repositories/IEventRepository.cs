using EMS.Core.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Application.Infrastructure.Persistence.Repositories
{
    public interface IEventRepository : IGenericRepository<Event>
    {
    }
}
