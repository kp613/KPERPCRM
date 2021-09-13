using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations.AppIdentityDb
{
    public partial class UserConnectePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectPerson",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectPersonPhone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectPerson",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConnectPersonPhone",
                table: "AspNetUsers");
        }
    }
}
