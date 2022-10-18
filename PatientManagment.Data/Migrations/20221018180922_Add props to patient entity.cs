using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagement.Data.Migrations
{
    public partial class Addpropstopatiententity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Patients",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Patients",
                newName: "FullName");
        }
    }
}
