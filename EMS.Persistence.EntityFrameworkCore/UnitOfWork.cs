using EMS.Core.Application.Infrastructure.Persistence;
using System;

namespace EMS.Persistence.EntityFrameworkCore
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
