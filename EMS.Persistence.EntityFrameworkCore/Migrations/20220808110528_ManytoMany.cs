using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    public partial class ManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteer_Events_EventId",
                table: "EventVolunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteer_Volunteers_VolunteerId",
                table: "EventVolunteer");

            migrationBuilder.RenameColumn(
                name: "VolunteerId",
                table: "EventVolunteer",
                newName: "SelectedVolunteersId");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventVolunteer",
                newName: "EventsAttendedId");

            migrationBuilder.RenameIndex(
                name: "IX_EventVolunteer_VolunteerId",
                table: "EventVolunteer",
                newName: "IX_EventVolunteer_SelectedVolunteersId");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Events",
                newName: "CreatedById");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDateUtc", "DeletedDateUtc", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDateUtc", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedById", "UserName" },
                values: new object[,]
                {
                    { "2D42B6A9-591B-4178-A4AB-431B3F337FD0", 0, "A034ED69-A8BA-4640-B54B-E941C75E79C2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationUser", "organiser@example.com", true, "Organiser", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Organiser", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "F9C0B1FE-F0DC-488D-8933-8E390E159602", false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Organiser" },
                    { "1BE12301-3337-4223-819D-9D36296AC6B9", 0, "434DBA35-5D04-413B-A8AF-6F61697A95F2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationUser", "volunteer1@example.com", true, "Volunteer1", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Volunteer1", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "898B708C-9012-41D7-A5EB-EF0B2DF38A76", false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Volunteer1" },
                    { "7DE1CD22-A7A7-4335-9060-24CECA03DE4F", 0, "2C73315D-35F6-4F92-84AF-CCDDDA419EA7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationUser", "volunteer2@example.com", true, "Volunteer2", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Volunteer2", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "ACC9E8C6-BEE1-49CC-9864-E41D6C9375A1", false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Volunteer2" },
                    { "71785F0B-D204-49C5-A5E8-12151829557F", 0, "B108FCD4-3B78-4A14-BA50-51EA387C104F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationUser", "volunteer3@example.com", true, "Volunteer3", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Volunteer3", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "07D9B532-D871-4288-813F-D9861F077ADB", false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Volunteer3" },
                    { "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1", 0, "D4EF185A-6D8C-40C3-949C-CBB178FFED34", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ApplicationUser", "volunteer4@example.com", true, "Volunteer4", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Volunteer4", "AQAAAAEAACcQAAAAELvNvu45ryG3Vyo/TYNAbPWDcm6C8lS/FAGigtMGlnhpPQzlOc9FI5AgmO6AQhx7Rw==", null, false, "D4897754-25F7-4C31-97D7-14E4A065A515", false, new Guid("84ada39a-2521-4e26-94f6-98d7e7a9bdd2"), "Volunteer4" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedById", "CreatedDateUtc", "DeletedDateUtc", "EndDate", "ModifiedDateUtc", "Name", "StartDate", "UpdatedById" },
                values: new object[,]
                {
                    { 1L, new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 6, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Miracle Experiment", new DateTime(2022, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0") },
                    { 2L, new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 8, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Revolutionary study", new DateTime(2022, 6, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "D8E8AFFC-3526-4B42-BCE2-C340BBD1875C", "2D42B6A9-591B-4178-A4AB-431B3F337FD0" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "1BE12301-3337-4223-819D-9D36296AC6B9" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "7DE1CD22-A7A7-4335-9060-24CECA03DE4F" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "71785F0B-D204-49C5-A5E8-12151829557F" },
                    { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EventVolunteer_Events_EventsAttendedId",
                table: "EventVolunteer",
                column: "EventsAttendedId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventVolunteer_Volunteers_SelectedVolunteersId",
                table: "EventVolunteer",
                column: "SelectedVolunteersId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteer_Events_EventsAttendedId",
                table: "EventVolunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteer_Volunteers_SelectedVolunteersId",
                table: "EventVolunteer");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "1BE12301-3337-4223-819D-9D36296AC6B9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "D8E8AFFC-3526-4B42-BCE2-C340BBD1875C", "2D42B6A9-591B-4178-A4AB-431B3F337FD0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "71785F0B-D204-49C5-A5E8-12151829557F" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "7DE1CD22-A7A7-4335-9060-24CECA03DE4F" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4F68DBC9-2EA8-43A9-9824-2FC38AFEBB0F", "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1" });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1BE12301-3337-4223-819D-9D36296AC6B9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2D42B6A9-591B-4178-A4AB-431B3F337FD0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71785F0B-D204-49C5-A5E8-12151829557F");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7DE1CD22-A7A7-4335-9060-24CECA03DE4F");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1");

            migrationBuilder.RenameColumn(
                name: "SelectedVolunteersId",
                table: "EventVolunteer",
                newName: "VolunteerId");

            migrationBuilder.RenameColumn(
                name: "EventsAttendedId",
                table: "EventVolunteer",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventVolunteer_SelectedVolunteersId",
                table: "EventVolunteer",
                newName: "IX_EventVolunteer_VolunteerId");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Events",
                newName: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_EventVolunteer_Events_EventId",
                table: "EventVolunteer",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventVolunteer_Volunteers_VolunteerId",
                table: "EventVolunteer",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
