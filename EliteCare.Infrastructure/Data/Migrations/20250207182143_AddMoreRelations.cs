using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteCare.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Appointments_AppointmentId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_AppointmentId",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "BillID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_AppointmentId",
                table: "Bills",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Appointments_AppointmentId",
                table: "Bills",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Appointments_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "ID");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Appointments_AppointmentId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Appointments_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Bills_AppointmentId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PrescriptionID",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_AppointmentId",
                table: "Bills",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Appointments_AppointmentId",
                table: "Bills",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
