using EMS.Core.Application.Domain;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EMSDbContext).Assembly);

            modelBuilder.Entity<Volunteer>()
               .HasOne(c => c.User)
               .WithOne()
               .HasForeignKey<Volunteer>(b => b.UserId);

            SeedDatabase(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            // order of seeding is important - don't change

            modelBuilder.SeedIdentityRoles();
            modelBuilder.SeedApplicationUsers();
            modelBuilder.SeedIdentityUserRoles();
            modelBuilder.SeedEventsAndVolunteers();
        }
    }
}