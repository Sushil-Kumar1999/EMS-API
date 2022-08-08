﻿// <auto-generated />
using System;
using EMS.Persistence.EntityFrameworkCore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(EMSDbContext))]
    [Migration("20220808110528_ManytoMany")]
    partial class ManytoMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMS.Core.Application.Domain.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedById = new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0"),
                            CreatedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2022, 6, 8, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "New Miracle Experiment",
                            StartDate = new DateTime(2022, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedById = new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0")
                        },
                        new
                        {
                            Id = 2L,
                            CreatedById = new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0"),
                            CreatedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2022, 8, 10, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Revolutionary study",
                            StartDate = new DateTime(2022, 6, 10, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedById = new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0")
                        });
                });

            modelBuilder.Entity("EMS.Core.Application.Domain.Volunteer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Age")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<DateTime>("ModifiedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("EventVolunteer", b =>
                {
                    b.Property<long>("EventsAttendedId")
                        .HasColumnType("bigint");

                    b.Property<long>("SelectedVolunteersId")
                        .HasColumnType("bigint");

                    b.HasKey("EventsAttendedId", "SelectedVolunteersId");

                    b.HasIndex("SelectedVolunteersId");

                    b.ToTable("EventVolunteer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "52FE810A-FBF4-4CC9-B74E-479F0998AA4B",
                            ConcurrencyStamp = "DCB26030-E62A-4F2A-BC3D-68F3C2C3939E",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "D8E8AFFC-3526-4B42-BCE2-C340BBD1875C",
                            ConcurrencyStamp = "C8891D4B-5195-441A-B819-5C08C47C0A0D",
                            Name = "Organiser",
                            NormalizedName = "Organiser"
                        },
                        new
                        {
                            Id = "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F",
                            ConcurrencyStamp = "A1912518-22E8-4F03-AEBF-609F084310A6",
                            Name = "Volunteer",
                            NormalizedName = "Volunteer"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "84ADA39A-2521-4E26-94F6-98D7E7A9BDD2",
                            RoleId = "52FE810A-FBF4-4CC9-B74E-479F0998AA4B"
                        },
                        new
                        {
                            UserId = "2D42B6A9-591B-4178-A4AB-431B3F337FD0",
                            RoleId = "D8E8AFFC-3526-4B42-BCE2-C340BBD1875C"
                        },
                        new
                        {
                            UserId = "1BE12301-3337-4223-819D-9D36296AC6B9",
                            RoleId = "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F"
                        },
                        new
                        {
                            UserId = "7DE1CD22-A7A7-4335-9060-24CECA03DE4F",
                            RoleId = "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F"
                        },
                        new
                        {
                            UserId = "71785F0B-D204-49C5-A5E8-12151829557F",
                            RoleId = "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F"
                        },
                        new
                        {
                            UserId = "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1",
                            RoleId = "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EMS.Core.Application.Domain.Users.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "84ADA39A-2521-4E26-94F6-98D7E7A9BDD2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "DCB26030-E62A-4F2A-BC3D-68F3C2C3939E",
                            Email = "superadmin@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "Admin",
                            PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "E2577F30-E5B1-481F-8E4A-CCEBB47642F2",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            CreatedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "SuperAdmin",
                            ModifiedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedById = new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2")
                        },
                        new
                        {
                            Id = "2D42B6A9-591B-4178-A4AB-431B3F337FD0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "A034ED69-A8BA-4640-B54B-E941C75E79C2",
                            Email = "organiser@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "Organiser",
                            PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "F9C0B1FE-F0DC-488D-8933-8E390E159602",
                            TwoFactorEnabled = false,
                            UserName = "Organiser",
                            CreatedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Organiser",
                            ModifiedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedById = new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2")
                        },
                        new
                        {
                            Id = "1BE12301-3337-4223-819D-9D36296AC6B9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "434DBA35-5D04-413B-A8AF-6F61697A95F2",
                            Email = "volunteer1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "Volunteer1",
                            PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "898B708C-9012-41D7-A5EB-EF0B2DF38A76",
                            TwoFactorEnabled = false,
                            UserName = "Volunteer1",
                            CreatedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Volunteer1",
                            ModifiedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedById = new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2")
                        },
                        new
                        {
                            Id = "7DE1CD22-A7A7-4335-9060-24CECA03DE4F",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2C73315D-35F6-4F92-84AF-CCDDDA419EA7",
                            Email = "volunteer2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "Volunteer2",
                            PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ACC9E8C6-BEE1-49CC-9864-E41D6C9375A1",
                            TwoFactorEnabled = false,
                            UserName = "Volunteer2",
                            CreatedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Volunteer2",
                            ModifiedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedById = new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2")
                        },
                        new
                        {
                            Id = "71785F0B-D204-49C5-A5E8-12151829557F",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "B108FCD4-3B78-4A14-BA50-51EA387C104F",
                            Email = "volunteer3@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "Volunteer3",
                            PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "07D9B532-D871-4288-813F-D9861F077ADB",
                            TwoFactorEnabled = false,
                            UserName = "Volunteer3",
                            CreatedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Volunteer3",
                            ModifiedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedById = new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2")
                        },
                        new
                        {
                            Id = "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "D4EF185A-6D8C-40C3-949C-CBB178FFED34",
                            Email = "volunteer4@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "Volunteer4",
                            PasswordHash = "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "D4897754-25F7-4C31-97D7-14E4A065A515",
                            TwoFactorEnabled = false,
                            UserName = "Volunteer4",
                            CreatedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Volunteer4",
                            ModifiedDateUtc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedById = new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2")
                        });
                });

            modelBuilder.Entity("EMS.Core.Application.Domain.Volunteer", b =>
                {
                    b.HasOne("EMS.Core.Application.Domain.Users.ApplicationUser", "User")
                        .WithOne()
                        .HasForeignKey("EMS.Core.Application.Domain.Volunteer", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventVolunteer", b =>
                {
                    b.HasOne("EMS.Core.Application.Domain.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsAttendedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Core.Application.Domain.Volunteer", null)
                        .WithMany()
                        .HasForeignKey("SelectedVolunteersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
