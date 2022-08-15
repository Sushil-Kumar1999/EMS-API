using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    public partial class UpdateEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1BE12301-3337-4223-819D-9D36296AC6B9",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 15, 15, 37, 17, 424, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71785F0B-D204-49C5-A5E8-12151829557F",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 15, 15, 37, 17, 424, DateTimeKind.Utc).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7DE1CD22-A7A7-4335-9060-24CECA03DE4F",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 15, 15, 37, 17, 424, DateTimeKind.Utc).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 15, 15, 37, 17, 424, DateTimeKind.Utc).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDateUtc", "Description", "Location", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 15, 15, 37, 17, 425, DateTimeKind.Utc).AddTicks(3288), "Hello world", "Barbados", new DateTime(2022, 8, 15, 15, 37, 17, 425, DateTimeKind.Utc).AddTicks(3294) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDateUtc", "Description", "Location", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 15, 15, 37, 17, 425, DateTimeKind.Utc).AddTicks(5604), "lorum epsum", "Antigua", new DateTime(2022, 8, 15, 15, 37, 17, 425, DateTimeKind.Utc).AddTicks(5607) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "Name");

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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDateUtc", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 9, 13, 19, 37, 732, DateTimeKind.Utc).AddTicks(8886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDateUtc", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 9, 13, 19, 37, 733, DateTimeKind.Utc).AddTicks(1531), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
