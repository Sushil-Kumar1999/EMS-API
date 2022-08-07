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

            modelBuilder.Entity<EventVolunteer>()
               .HasKey(ev => new { ev.EventId, ev.VolunteerId });

            modelBuilder.Entity<EventVolunteer>()
                .HasOne(ev => ev.Event)
                .WithMany(e => e.SelectedVolunteers);

            modelBuilder.Entity<EventVolunteer>()
                .HasOne(ev => ev.Volunteer)
                .WithMany(e => e.EventsAttended);

            SeedDatabase(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedAdminAndRoles();
        }
    }
}