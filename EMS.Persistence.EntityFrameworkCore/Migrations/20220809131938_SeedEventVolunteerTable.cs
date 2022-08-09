using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    public partial class SeedEventVolunteerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1BE12301-3337-4223-819D-9D36296AC6B9",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 13, 19, 37, 731, DateTimeKind.Utc).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71785F0B-D204-49C5-A5E8-12151829557F",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 13, 19, 37, 731, DateTimeKind.Utc).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7DE1CD22-A7A7-4335-9060-24CECA03DE4F",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 13, 19, 37, 731, DateTimeKind.Utc).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 13, 19, 37, 731, DateTimeKind.Utc).AddTicks(4309));

            migrationBuilder.InsertData(
                table: "EventVolunteer",
                columns: new[] { "EventsId", "VolunteersId" },
                values: new object[,]
                {
                    { 1L, "1BE12301-3337-4223-819D-9D36296AC6B9" },
                    { 1L, "7DE1CD22-A7A7-4335-9060-24CECA03DE4F" },
                    { 2L, "71785F0B-D204-49C5-A5E8-12151829557F" },
                    { 2L, "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 8, 9, 13, 19, 37, 732, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 8, 9, 13, 19, 37, 733, DateTimeKind.Utc).AddTicks(1531));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventVolunteer",
                keyColumns: new[] { "EventsId", "VolunteersId" },
                keyValues: new object[] { 1L, "1BE12301-3337-4223-819D-9D36296AC6B9" });

            migrationBuilder.DeleteData(
                table: "EventVolunteer",
                keyColumns: new[] { "EventsId", "VolunteersId" },
                keyValues: new object[] { 1L, "7DE1CD22-A7A7-4335-9060-24CECA03DE4F" });

            migrationBuilder.DeleteData(
                table: "EventVolunteer",
                keyColumns: new[] { "EventsId", "VolunteersId" },
                keyValues: new object[] { 2L, "71785F0B-D204-49C5-A5E8-12151829557F" });

            migrationBuilder.DeleteData(
                table: "EventVolunteer",
                keyColumns: new[] { "EventsId", "VolunteersId" },
                keyValues: new object[] { 2L, "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1BE12301-3337-4223-819D-9D36296AC6B9",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 13, 8, 44, 196, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71785F0B-D204-49C5-A5E8-12151829557F",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 13, 8, 44, 196, DateTimeKind.Utc).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7DE1CD22-A7A7-4335-9060-24CECA03DE4F",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 13, 8, 44, 196, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 13, 8, 44, 196, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 8, 9, 13, 8, 44, 197, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDateUtc",
                value: new DateTime(2022, 8, 9, 13, 8, 44, 197, DateTimeKind.Utc).AddTicks(8846));
        }
    }
}
