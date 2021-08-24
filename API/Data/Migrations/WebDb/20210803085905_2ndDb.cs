using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations.WebDb
{
    public partial class _2ndDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPublishing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CASNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductNameCN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPublishing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebMessageCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebMessageCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MsgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Finalizer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Auditor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ApplyingFor = table.Column<bool>(type: "bit", nullable: false),
                    Updatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebMessageCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebMessage_WebMessageCategory_WebMessageCategoryId",
                        column: x => x.WebMessageCategoryId,
                        principalTable: "WebMessageCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebMessage_WebUser_AuditorId",
                        column: x => x.AuditorId,
                        principalTable: "WebUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebMessage_WebUser_Finalizer",
                        column: x => x.Finalizer,
                        principalTable: "WebUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebMessage_WebUser_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "WebUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebMessage_AuditorId",
                table: "WebMessage",
                column: "AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_WebMessage_Finalizer",
                table: "WebMessage",
                column: "Finalizer");

            migrationBuilder.CreateIndex(
                name: "IX_WebMessage_PublisherId",
                table: "WebMessage",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_WebMessage_WebMessageCategoryId",
                table: "WebMessage",
                column: "WebMessageCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPublishing");

            migrationBuilder.DropTable(
                name: "WebMessage");

            migrationBuilder.DropTable(
                name: "WebMessageCategory");

            migrationBuilder.DropTable(
                name: "WebUser");
        }
    }
}
