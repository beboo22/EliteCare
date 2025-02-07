using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteCare.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BillID",
                table: "Appointments",
                column: "BillID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PrescriptionID",
                table: "Appointments",
                column: "PrescriptionID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Bills_BillID",
                table: "Appointments",
                column: "BillID",
                principalTable: "Bills",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Prescriptions_PrescriptionID",
                table: "Appointments",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Bills_BillID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Prescriptions_PrescriptionID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BillID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PrescriptionID",
                table: "Appointments");

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
    }
}
