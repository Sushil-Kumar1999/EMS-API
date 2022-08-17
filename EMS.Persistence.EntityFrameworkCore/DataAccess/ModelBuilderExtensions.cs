using EMS.Core.Application.Domain.Events;
using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EMS.Persistence.EntityFrameworkCore.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static readonly string AdminId = "84ADA39A-2521-4E26-94F6-98D7E7A9BDD2";
        public static readonly string OrganiserId = "2D42B6A9-591B-4178-A4AB-431B3F337FD0";
        public static readonly string Volunteer1Id = "1BE12301-3337-4223-819D-9D36296AC6B9";
        public static readonly string Volunteer2Id = "7DE1CD22-A7A7-4335-9060-24CECA03DE4F";
        public static readonly string Volunteer3Id = "71785F0B-D204-49C5-A5E8-12151829557F";
        public static readonly string Volunteer4Id = "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1";

        public static readonly string AdminRoleId = "52FE810A-FBF4-4CC9-B74E-479F0998AA4B";
        public static readonly string OrganiserRoleId = "D8E8AFFC-3526-4B42-BCE2-C340BBD1875C";
        public static readonly string VolunteerRoleId = "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F";

        public static void SeedIdentityRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = AdminRoleId,
                    ConcurrencyStamp = "DCB26030-E62A-4F2A-BC3D-68F3C2C3939E",
                    Name = UserRoles.Admin.ToString(),
                    NormalizedName = UserRoles.Admin.ToString(),
                },
                new IdentityRole
                {
                    Id = OrganiserRoleId,
                    ConcurrencyStamp = "C8891D4B-5195-441A-B819-5C08C47C0A0D",
                    Name = UserRoles.Organiser.ToString(),
                    NormalizedName = UserRoles.Organiser.ToString(),
                },
                new IdentityRole
                {
                    Id = VolunteerRoleId,
                    ConcurrencyStamp = "A1912518-22E8-4F03-AEBF-609F084310A6",
                    Name = UserRoles.Volunteer.ToString(),
                    NormalizedName = UserRoles.Volunteer.ToString(),
                });
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            // all passwords are Admin123!

            ApplicationUser admin = new ApplicationUser
            {
                Id = AdminId,
                ConcurrencyStamp = "DCB26030-E62A-4F2A-BC3D-68F3C2C3939E",
                SecurityStamp = "E2577F30-E5B1-481F-8E4A-CCEBB47642F2",
                UserName = UserRoles.Admin.ToString(),
                NormalizedUserName = UserRoles.Admin.ToString(),
                Email = "superadmin@example.com",
                EmailConfirmed = true,
                FirstName = "SuperAdmin",
                PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==",
                UpdatedById = Guid.Parse(AdminId)
            };

            ApplicationUser organiser = new ApplicationUser
            {
                Id = OrganiserId,
                ConcurrencyStamp = "A034ED69-A8BA-4640-B54B-E941C75E79C2",
                SecurityStamp = "F9C0B1FE-F0DC-488D-8933-8E390E159602",
                UserName = UserRoles.Organiser.ToString(),
                NormalizedUserName = UserRoles.Organiser.ToString(),
                Email = "organiser@example.com",
                EmailConfirmed = true,
                FirstName = "Organiser",
                PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", // Admin123!
                UpdatedById = Guid.Parse(AdminId)
            };

            modelBuilder.Entity<ApplicationUser>().HasData(admin, organiser);

            var volunteer1 = new Volunteer
            {
                Id = Volunteer1Id,
                ConcurrencyStamp = "434DBA35-5D04-413B-A8AF-6F61697A95F2",
                SecurityStamp = "898B708C-9012-41D7-A5EB-EF0B2DF38A76",
                UserName = "Volunteer1",
                NormalizedUserName = "Volunteer1",
                Email = "volunteer1@example.com",
                EmailConfirmed = true,
                FirstName = "Volunteer1",
                PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", // Admin123!
                UpdatedById = Guid.Parse(AdminId),
                DateOfBirth = new DateTime(2000, 8, 15, 15, 37, 17),
                Height = 1,
                Weight = 1
            };
            var volunteer2 = new Volunteer
            {
                Id = Volunteer2Id,
                ConcurrencyStamp = "2C73315D-35F6-4F92-84AF-CCDDDA419EA7",
                SecurityStamp = "ACC9E8C6-BEE1-49CC-9864-E41D6C9375A1",
                UserName = "Volunteer2",
                NormalizedUserName = "Volunteer2",
                Email = "volunteer2@example.com",
                EmailConfirmed = true,
                FirstName = "Volunteer2",
                PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", // Admin123!
                UpdatedById = Guid.Parse(AdminId),
                DateOfBirth = new DateTime(1973, 8, 15),
                Height = 1,
                Weight = 1
            };
            var volunteer3 = new Volunteer
            {
                Id = Volunteer3Id,
                ConcurrencyStamp = "B108FCD4-3B78-4A14-BA50-51EA387C104F",
                SecurityStamp = "07D9B532-D871-4288-813F-D9861F077ADB",
                UserName = "Volunteer3",
                NormalizedUserName = "Volunteer3",
                Email = "volunteer3@example.com",
                EmailConfirmed = true,
                FirstName = "Volunteer3",
                PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", // Admin123!
                UpdatedById = Guid.Parse(AdminId),
                DateOfBirth = new DateTime(198, 6, 19),
                Height = 1,
                Weight = 1
            };
            var volunteer4 = new Volunteer
            {
                Id = Volunteer4Id,
                ConcurrencyStamp = "D4EF185A-6D8C-40C3-949C-CBB178FFED34",
                SecurityStamp = "D4897754-25F7-4C31-97D7-14E4A065A515",
                UserName = "Volunteer4",
                NormalizedUserName = "Volunteer4",
                Email = "volunteer4@example.com",
                EmailConfirmed = true,
                FirstName = "Volunteer4",
                PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", // Admin123!
                UpdatedById = Guid.Parse(AdminId),
                DateOfBirth = new DateTime(1992, 1, 1),
                Height = 1,
                Weight = 1
            };

            modelBuilder.Entity<Volunteer>().HasData(volunteer1, volunteer2, volunteer3, volunteer4);
        }

        public static void SeedIdentityUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                 new IdentityUserRole<string>()
                 {
                     RoleId = AdminRoleId,
                     UserId = AdminId
                 },
                 new IdentityUserRole<string>()
                 {
                     RoleId = OrganiserRoleId,
                     UserId = OrganiserId
                 },
                 new IdentityUserRole<string>()
                 {
                     RoleId = VolunteerRoleId,
                     UserId = Volunteer1Id
                 },
                 new IdentityUserRole<string>()
                 {
                     RoleId = VolunteerRoleId,
                     UserId = Volunteer2Id
                 },
                 new IdentityUserRole<string>()
                 {
                     RoleId = VolunteerRoleId,
                     UserId = Volunteer3Id
                 },
                 new IdentityUserRole<string>()
                 {
                     RoleId = VolunteerRoleId,
                     UserId = Volunteer4Id
                 }
             );
        }

        public static void SeedEvents(this ModelBuilder modelBuilder)
        {
            var events = new[]
            {
                new Event
                {
                    Id = 1,
                    Title = "New Miracle Experiment",
                    Description = "Hello world",
                    Location = "Barbados",
                    CreatedById = Guid.Parse(OrganiserId),
                    StartDate = new DateTime(2022, 6, 8, 9, 0, 0),
                    EndDate = new DateTime(2022, 6, 8, 17, 0, 0)
                },
                new Event
                {
                    Id = 2,
                    Title = "Revolutionary study",
                    Description = "lorum epsum",
                    Location = "Antigua",
                    CreatedById = Guid.Parse(OrganiserId),
                    StartDate = new DateTime(2022, 6, 10, 9, 0, 0),
                    EndDate = new DateTime(2022, 8, 10, 17, 0, 0)
                }
            };

            modelBuilder.Entity<Event>().HasData(events);
        }

        public static void SeedEventVolunteerTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("EventVolunteer").HasData(
                new { EventsId = 1L, VolunteersId = Volunteer1Id },
                new { EventsId = 1L, VolunteersId = Volunteer2Id },
                new { EventsId = 2L, VolunteersId = Volunteer3Id },
                new { EventsId = 2L, VolunteersId = Volunteer4Id }
            );
        }
    }
}
