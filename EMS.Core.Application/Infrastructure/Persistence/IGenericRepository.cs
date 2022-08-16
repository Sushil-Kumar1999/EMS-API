using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Application.Infrastructure.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();

        Task<T> GetByIdAsync(long Id);

        Task<bool> AddAsync(T entity);

        Task<bool> DeleteAsync(string Id);

        Task<bool> UpsertAsync(T entity);

    }
}
