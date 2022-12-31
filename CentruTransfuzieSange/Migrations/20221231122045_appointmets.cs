using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentruTransfuzieSange.Migrations
{
    public partial class appointmets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_MedicalService_MedicalServicesID",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Member",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Member",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Member",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MedicalServicesID",
                table: "Appointment",
                newName: "MedicalServiceID");

            migrationBuilder.RenameColumn(
                name: "MedicalService",
                table: "Appointment",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_MedicalServicesID",
                table: "Appointment",
                newName: "IX_Appointment_MedicalServiceID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Member",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Member",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Member",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorID",
                table: "Appointment",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_MedicalService_MedicalServiceID",
                table: "Appointment",
                column: "MedicalServiceID",
                principalTable: "MedicalService",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_MedicalService_MedicalServiceID",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DoctorID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Member",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Member",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Member",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MedicalServiceID",
                table: "Appointment",
                newName: "MedicalServicesID");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Appointment",
                newName: "MedicalService");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_MedicalServiceID",
                table: "Appointment",
                newName: "IX_Appointment_MedicalServicesID");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_MedicalService_MedicalServicesID",
                table: "Appointment",
                column: "MedicalServicesID",
                principalTable: "MedicalService",
                principalColumn: "ID");
        }
    }
}
