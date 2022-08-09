using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Application.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task CompleteAsync();
        void Rollback();
        T Clone<T>(T entity);
    }
}
