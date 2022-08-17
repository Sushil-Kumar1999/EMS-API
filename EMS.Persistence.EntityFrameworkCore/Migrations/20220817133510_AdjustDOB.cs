using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    public partial class AdjustDOB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1BE12301-3337-4223-819D-9D36296AC6B9",
                column: "DateOfBirth",
                value: new DateTime(2000, 8, 15, 15, 37, 17, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71785F0B-D204-49C5-A5E8-12151829557F",
                column: "DateOfBirth",
                value: new DateTime(198, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7DE1CD22-A7A7-4335-9060-24CECA03DE4F",
                column: "DateOfBirth",
                value: new DateTime(1973, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1",
                column: "DateOfBirth",
                value: new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDateUtc", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 17, 13, 35, 9, 466, DateTimeKind.Utc).AddTicks(8083), new DateTime(2022, 8, 17, 13, 35, 9, 466, DateTimeKind.Utc).AddTicks(8097) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDateUtc", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 17, 13, 35, 9, 467, DateTimeKind.Utc).AddTicks(1159), new DateTime(2022, 8, 17, 13, 35, 9, 467, DateTimeKind.Utc).AddTicks(1163) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedDateUtc", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 15, 15, 37, 17, 425, DateTimeKind.Utc).AddTicks(3288), new DateTime(2022, 8, 15, 15, 37, 17, 425, DateTimeKind.Utc).AddTicks(3294) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDateUtc", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 15, 15, 37, 17, 425, DateTimeKind.Utc).AddTicks(5604), new DateTime(2022, 8, 15, 15, 37, 17, 425, DateTimeKind.Utc).AddTicks(5607) });
        }
    }
}
