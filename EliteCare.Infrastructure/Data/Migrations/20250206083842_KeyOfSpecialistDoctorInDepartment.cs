using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteCare.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class KeyOfSpecialistDoctorInDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorID1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientID1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Receptionists_ReceptionistID1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorID1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientID1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ReceptionistID1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "DoctorID1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientID1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ReceptionistID1",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Receptionists",
                newName: "Sname");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Receptionists",
                type: "NVARCHAR(max)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Receptionists",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Receptionists",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Receptionists",
                type: "NVARCHAR(max)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Receptionists",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "Receptionists",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lname",
                table: "Receptionists",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Bills",
                type: "NVARCHAR(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fname",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "Lname",
                table: "Receptionists");

            migrationBuilder.RenameColumn(
                name: "Sname",
                table: "Receptionists",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(max)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Receptionists",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Receptionists",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Receptionists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(max)",
                oldMaxLength: 2147483647);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Receptionists",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Receptionists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Bills",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorID1",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientID1",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceptionistID1",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorID1",
                table: "Appointments",
                column: "DoctorID1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID1",
                table: "Appointments",
                column: "PatientID1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ReceptionistID1",
                table: "Appointments",
                column: "ReceptionistID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorID1",
                table: "Appointments",
                column: "DoctorID1",
                principalTable: "Doctors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientID1",
                table: "Appointments",
                column: "PatientID1",
                principalTable: "Patients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Receptionists_ReceptionistID1",
                table: "Appointments",
                column: "ReceptionistID1",
                principalTable: "Receptionists",
                principalColumn: "ID");
        }
    }
}
