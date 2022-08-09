using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedById", "CreatedDateUtc", "DeletedDateUtc", "EndDate", "ModifiedDateUtc", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1L, new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0"), new DateTime(2022, 8, 9, 13, 8, 44, 197, DateTimeKind.Utc).AddTicks(6736), null, new DateTime(2022, 6, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Miracle Experiment", new DateTime(2022, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2L, new Guid("2d42b6a9-591b-4178-a4ab-431b3f337fd0"), new DateTime(2022, 8, 9, 13, 8, 44, 197, DateTimeKind.Utc).AddTicks(8846), null, new DateTime(2022, 8, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Revolutionary study", new DateTime(2022, 6, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1BE12301-3337-4223-819D-9D36296AC6B9",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 12, 54, 24, 564, DateTimeKind.Utc).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71785F0B-D204-49C5-A5E8-12151829557F",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 12, 54, 24, 564, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7DE1CD22-A7A7-4335-9060-24CECA03DE4F",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 12, 54, 24, 564, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F312FB13-12EF-4F93-8F16-A9C9A0CEA4C1",
                column: "DateOfBirth",
                value: new DateTime(2022, 8, 9, 12, 54, 24, 564, DateTimeKind.Utc).AddTicks(3698));
        }
    }
}
