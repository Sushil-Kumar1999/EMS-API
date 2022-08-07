using EMS.Core.Application.Domain.Enums;
using EMS.Core.Application.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EMS.Persistence.EntityFrameworkCore.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void SeedAdminAndRoles(this ModelBuilder modelBuilder)
        {
            var adminId = "84ADA39A-2521-4E26-94F6-98D7E7A9BDD2";
            var adminRoleId = "52FE810A-FBF4-4CC9-B74E-479F0998AA4B";

            ApplicationUser user = new ApplicationUser
            {
                Id = adminId,
                ConcurrencyStamp = "DCB26030-E62A-4F2A-BC3D-68F3C2C3939E",
                SecurityStamp = "E2577F30-E5B1-481F-8E4A-CCEBB47642F2",
                UserName = UserRoles.Admin.ToString(),
                NormalizedUserName = UserRoles.Admin.ToString(),
                Email = "superadmin@example.com",
                EmailConfirmed = true,
                FirstName = "SuperAdmin",
                PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", // Admin123!
                UpdatedById = Guid.Parse(adminId)
            };

            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = "DCB26030-E62A-4F2A-BC3D-68F3C2C3939E",
                    Name = UserRoles.Admin.ToString(),
                    NormalizedName = UserRoles.Admin.ToString(),
                },
                new IdentityRole
                {
                    Id = "D8E8AFFC-3526-4B42-BCE2-C340BBD1875C",
                    ConcurrencyStamp = "C8891D4B-5195-441A-B819-5C08C47C0A0D",
                    Name = UserRoles.Organiser.ToString(),
                    NormalizedName = UserRoles.Organiser.ToString(),
                },
                new IdentityRole
                {
                    Id = "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F",
                    ConcurrencyStamp = "A1912518-22E8-4F03-AEBF-609F084310A6",
                    Name = UserRoles.Volunteer.ToString(),
                    NormalizedName = UserRoles.Volunteer.ToString(),
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                });
        }
    }
}
