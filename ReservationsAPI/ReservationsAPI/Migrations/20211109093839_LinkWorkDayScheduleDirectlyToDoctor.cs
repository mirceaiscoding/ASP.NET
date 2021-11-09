using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationsAPI.Migrations
{
    public partial class LinkWorkDayScheduleDirectlyToDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDaySchedules_WorkSchedules_WorkScheduleId",
                table: "WorkDaySchedules");

            migrationBuilder.DropTable(
                name: "WorkSchedules");

            migrationBuilder.RenameColumn(
                name: "WorkScheduleId",
                table: "WorkDaySchedules",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkDaySchedules_WorkScheduleId",
                table: "WorkDaySchedules",
                newName: "IX_WorkDaySchedules_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDaySchedules_Doctors_DoctorId",
                table: "WorkDaySchedules",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDaySchedules_Doctors_DoctorId",
                table: "WorkDaySchedules");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "WorkDaySchedules",
                newName: "WorkScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkDaySchedules_DoctorId",
                table: "WorkDaySchedules",
                newName: "IX_WorkDaySchedules_WorkScheduleId");

            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_DoctorId",
                table: "WorkSchedules",
                column: "DoctorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDaySchedules_WorkSchedules_WorkScheduleId",
                table: "WorkDaySchedules",
                column: "WorkScheduleId",
                principalTable: "WorkSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
