using EMS.Core.Application.Domain.Users;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Persistence.EntityFrameworkCore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistence.EntityFrameworkCore.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(EMSDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<ApplicationUser>> ListAsync()
        {
            return await _dbSet.Where(x => x.Status == 1)
                                .AsNoTracking()
                                .ToListAsync();
        }
    }
}
