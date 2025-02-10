using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteCare.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                            name: "IX_Appointments_BillID",
                            table: "Appointments");
            migrationBuilder.DropIndex(
                            name: "IX_Appointments_PrescriptionID",
                            table: "Appointments");
            migrationBuilder.DropIndex(
                            name: "IX_Appointments_ReceptionistID",
                            table: "Appointments");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
