using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class ChangeAppointmentCompositeKeyOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PacientId",
                table: "Appointments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                columns: new[] { "PacientId", "DoctorId", "ProcedureId", "StartTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                columns: new[] { "DoctorId", "PacientId", "ProcedureId", "StartTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PacientId",
                table: "Appointments",
                column: "PacientId");
        }
    }
}
