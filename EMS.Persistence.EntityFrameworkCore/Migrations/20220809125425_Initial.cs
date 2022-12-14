using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVolunteer",
                columns: table => new
                {
                    EventsId = table.Column<long>(type: "bigint", nullable: false),
                    VolunteersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVolunteer", x => new { x.EventsId, x.VolunteersId });
                    table.ForeignKey(
                        name: "FK_EventVolunteer_AspNetUsers_VolunteersId",
                        column: x => x.VolunteersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVolunteer_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52FE810A-FBF4-4CC9-B74E-479F0998AA4B", "DCB26030-E62A-4F2A-BC3D-68F3C2C3939E", "Admin", "Admin" },
                    { "D8E8AFFC-3526-4B42-BCE2-C340BBD1875C", "C8891D4B-5195-441A-B819-5C08C47C0A0D", "Organiser", "Organiser" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "A1912518-22E8-4F03-AEBF-609F084310A6", "Volunteer", "Volunteer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDateUtc", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDateUtc", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedById", "UserName" },
                values: new object[,]
                {
                    { "84ADA39A-2521-4E26-94F6-98D7E7A9BDD2", 0, "DCB26030-E62A-4F2A-BC3D-68F3C2C3939E", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ApplicationUser", "superadmin@example.com", true, "SuperAdmin", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "E2577F30-E5B1-481F-8E4A-CCEBB47642F2", 1, false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Admin" },
                    { "2D42B6A9-591B-4178-A4AB-431B3F337FD0", 0, "A034ED69-A8BA-4640-B54B-E941C75E79C2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ApplicationUser", "organiser@example.com", true, "Organiser", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Organiser", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "F9C0B1FE-F0DC-488D-8933-8E390E159602", 1, false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Organiser" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDateUtc", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Height", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDateUtc", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedById", "UserName", "Weight" },
                values: new object[,]
                {
                    { "1BE12301-3337-4223-819D-9D36296AC6B9", 0, "434DBA35-5D04-413B-A8AF-6F61697A95F2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 9, 12, 54, 24, 564, DateTimeKind.Utc).AddTicks(706), "Volunteer", "volunteer1@example.com", true, "Volunteer1", 1.0, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Volunteer1", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "898B708C-9012-41D7-A5EB-EF0B2DF38A76", 1, false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Volunteer1", 1.0 },
                    { "7DE1CD22-A7A7-4335-9060-24CECA03DE4F", 0, "2C73315D-35F6-4F92-84AF-CCDDDA419EA7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 9, 12, 54, 24, 564, DateTimeKind.Utc).AddTicks(3639), "Volunteer", "volunteer2@example.com", true, "Volunteer2", 1.0, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Volunteer2", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "ACC9E8C6-BEE1-49CC-9864-E41D6C9375A1", 1, false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Volunteer2", 1.0 },
                    { "71785F0B-D204-49C5-A5E8-12151829557F", 0, "B108FCD4-3B78-4A14-BA50-51EA387C104F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 9, 12, 54, 24, 564, DateTimeKind.Utc).AddTicks(3675), "Volunteer", "volunteer3@example.com", true, "Volunteer3", 1.0, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Volunteer3", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "07D9B532-D871-4288-813F-D9861F077ADB", 1, false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Volunteer3", 1.0 },
                    { "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1", 0, "D4EF185A-6D8C-40C3-949C-CBB178FFED34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 9, 12, 54, 24, 564, DateTimeKind.Utc).AddTicks(3698), "Volunteer", "volunteer4@example.com", true, "Volunteer4", 1.0, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Volunteer4", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "D4897754-25F7-4C31-97D7-14E4A065A515", 1, false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Volunteer4", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "52FE810A-FBF4-4CC9-B74E-479F0998AA4B", "84ADA39A-2521-4E26-94F6-98D7E7A9BDD2" },
                    { "D8E8AFFC-3526-4B42-BCE2-C340BBD1875C", "2D42B6A9-591B-4178-A4AB-431B3F337FD0" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "1BE12301-3337-4223-819D-9D36296AC6B9" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "7DE1CD22-A7A7-4335-9060-24CECA03DE4F" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "71785F0B-D204-49C5-A5E8-12151829557F" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EventVolunteer_VolunteersId",
                table: "EventVolunteer",
                column: "VolunteersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EventVolunteer");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
