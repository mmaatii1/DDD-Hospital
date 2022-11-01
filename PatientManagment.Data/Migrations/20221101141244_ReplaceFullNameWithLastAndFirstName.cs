using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagement.Data.Migrations
{
    public partial class ReplaceFullNameWithLastAndFirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "StuffMember",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "StuffMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "StuffMember");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "StuffMember",
                newName: "FullName");
        }
    }
}
