using EMS.Core.Application.Domain.Users;
using EMS.Core.Application.Domain.Users.QueryObjects;
using EMS.Core.Application.Infrastructure.Persistence.Repositories;
using EMS.Persistence.EntityFrameworkCore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Persistence.EntityFrameworkCore.Repositories
{
    public class VolunteerRepository : GenericRepository<Volunteer>, IVolunteerRepository
    {
        public VolunteerRepository(EMSDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Volunteer>> FindAsync(FilterVolunteersQueryObject query)
        {
            IEnumerable<Volunteer> results =  await _dbSet
                .Where(x => x.Status == 1)
                .Where(x => x.Height > query.MinHeight && x.Height < query.MaxHeight
                         && x.Weight > query.MinWeight && x.Weight < query.MaxWeight)
                .AsNoTracking()
                .ToListAsync();

            return results.Where(x => isWithinAgeRange(x.DateOfBirth, query.MinAge, query.MaxAge));
        }

        private bool isWithinAgeRange(DateTime birthDate, double minAge, double maxAge)
        {
            double age = (DateTime.Now - birthDate).TotalDays / 365.242199;

            return (age > minAge && age < maxAge);
        }
    }
}
