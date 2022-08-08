using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.EntityFrameworkCore.Migrations
{
    public partial class Convention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteer_Events_EventsAttendedId",
                table: "EventVolunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteer_Volunteers_SelectedVolunteersId",
                table: "EventVolunteer");

            migrationBuilder.RenameColumn(
                name: "SelectedVolunteersId",
                table: "EventVolunteer",
                newName: "VolunteersId");

            migrationBuilder.RenameColumn(
                name: "EventsAttendedId",
                table: "EventVolunteer",
                newName: "EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_EventVolunteer_SelectedVolunteersId",
                table: "EventVolunteer",
                newName: "IX_EventVolunteer_VolunteersId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventVolunteer_Events_EventsId",
                table: "EventVolunteer",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventVolunteer_Volunteers_VolunteersId",
                table: "EventVolunteer",
                column: "VolunteersId",
                principalTable: "Volunteers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteer_Events_EventsId",
                table: "EventVolunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_EventVolunteer_Volunteers_VolunteersId",
                table: "EventVolunteer");

            migrationBuilder.RenameColumn(
                name: "VolunteersId",
                table: "EventVolunteer",
                newName: "SelectedVolunteersId");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "EventVolunteer",
                newName: "EventsAttendedId");

            migrationBuilder.RenameIndex(
                name: "IX_EventVolunteer_VolunteersId",
                table: "EventVolunteer",
                newName: "IX_EventVolunteer_SelectedVolunteersId");

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
    }
}
