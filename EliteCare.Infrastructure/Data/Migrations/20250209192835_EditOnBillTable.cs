using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteCare.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditOnBillTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OdrederID",
                table: "Bills",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdrederID",
                table: "Bills");
        }
    }
}
