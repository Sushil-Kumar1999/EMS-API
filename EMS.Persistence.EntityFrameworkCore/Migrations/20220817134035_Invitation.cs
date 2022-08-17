using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    public partial class Invitation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    VolunteerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvitationStatus = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDateUtc", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 17, 13, 40, 34, 816, DateTimeKind.Utc).AddTicks(2405), new DateTime(2022, 8, 17, 13, 40, 34, 816, DateTimeKind.Utc).AddTicks(2418) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDateUtc", "ModifiedDateUtc" },
                values: new object[] { new DateTime(2022, 8, 17, 13, 40, 34, 816, DateTimeKind.Utc).AddTicks(4643), new DateTime(2022, 8, 17, 13, 40, 34, 816, DateTimeKind.Utc).AddTicks(4646) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitations");

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
    }
}
