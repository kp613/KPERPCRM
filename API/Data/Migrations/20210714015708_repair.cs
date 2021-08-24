using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class repair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductListInTypes_Products_ProductId",
                table: "ProductListInTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductListInTypes_ProductTypes_ProductTypeId",
                table: "ProductListInTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductListInTypes",
                table: "ProductListInTypes");

            migrationBuilder.RenameTable(
                name: "ProductListInTypes",
                newName: "ProductListInType");

            migrationBuilder.RenameIndex(
                name: "IX_ProductListInTypes_ProductTypeId",
                table: "ProductListInType",
                newName: "IX_ProductListInType_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductListInTypes_ProductId",
                table: "ProductListInType",
                newName: "IX_ProductListInType_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductListInType",
                table: "ProductListInType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductListInType_Products_ProductId",
                table: "ProductListInType",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductListInType_ProductTypes_ProductTypeId",
                table: "ProductListInType",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductListInType_Products_ProductId",
                table: "ProductListInType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductListInType_ProductTypes_ProductTypeId",
                table: "ProductListInType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductListInType",
                table: "ProductListInType");

            migrationBuilder.RenameTable(
                name: "ProductListInType",
                newName: "ProductListInTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductListInType_ProductTypeId",
                table: "ProductListInTypes",
                newName: "IX_ProductListInTypes_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductListInType_ProductId",
                table: "ProductListInTypes",
                newName: "IX_ProductListInTypes_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductListInTypes",
                table: "ProductListInTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductListInTypes_Products_ProductId",
                table: "ProductListInTypes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductListInTypes_ProductTypes_ProductTypeId",
                table: "ProductListInTypes",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
