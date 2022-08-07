using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMS.Persistence.EntityFrameworkCore.DataAccess
{
    public class EMSDbContext : IdentityDbContext
    {
        public EMSDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}