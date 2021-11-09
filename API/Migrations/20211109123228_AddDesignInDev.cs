using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddDesignInDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesignRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgressAndProblem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrudState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignRecord");
        }
    }
}
