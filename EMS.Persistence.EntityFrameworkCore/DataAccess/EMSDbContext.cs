using EMS.Core.Application.Domain.Events;
using EMS.Core.Application.Domain.Invitations;
using EMS.Core.Application.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMS.Persistence.EntityFrameworkCore.DataAccess
{
    public class EMSDbContext : IdentityDbContext
    {
        public EMSDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EMSDbContext).Assembly);

            SeedDatabase(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            // order of seeding is important - don't change

            modelBuilder.SeedIdentityRoles();
            modelBuilder.SeedUsers();
            modelBuilder.SeedIdentityUserRoles();
            modelBuilder.SeedEvents();
            modelBuilder.SeedEventVolunteerTable();
        }
    }
}