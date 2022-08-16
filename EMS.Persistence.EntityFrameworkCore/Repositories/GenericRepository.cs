using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Persistence.EntityFrameworkCore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Persistence.EntityFrameworkCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EMSDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(EMSDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(string Id)
        {
            return true;
        }

        public virtual async Task<T> GetByIdAsync(long Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<bool> UpsertAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
