using Microsoft.EntityFrameworkCore.Migrations;

namespace API.data.migrations.applicationdb
{
    public partial class ProductsInitialrepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsGroupThirdProduct_Products_ProductId",
                table: "ProductsGroupThirdProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsGroupThirdProduct_ProductsGroupThird_ProductsGroupThirdId",
                table: "ProductsGroupThirdProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsGroupThirdProduct",
                table: "ProductsGroupThirdProduct");

            migrationBuilder.RenameTable(
                name: "ProductsGroupThirdProduct",
                newName: "ProductsGroupThirdProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsGroupThirdProduct_ProductsGroupThirdId",
                table: "ProductsGroupThirdProducts",
                newName: "IX_ProductsGroupThirdProducts_ProductsGroupThirdId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsGroupThirdProduct_ProductId",
                table: "ProductsGroupThirdProducts",
                newName: "IX_ProductsGroupThirdProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsGroupThirdProducts",
                table: "ProductsGroupThirdProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsGroupThirdProducts_Products_ProductId",
                table: "ProductsGroupThirdProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsGroupThirdProducts_ProductsGroupThird_ProductsGroupThirdId",
                table: "ProductsGroupThirdProducts",
                column: "ProductsGroupThirdId",
                principalTable: "ProductsGroupThird",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsGroupThirdProducts_Products_ProductId",
                table: "ProductsGroupThirdProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsGroupThirdProducts_ProductsGroupThird_ProductsGroupThirdId",
                table: "ProductsGroupThirdProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsGroupThirdProducts",
                table: "ProductsGroupThirdProducts");

            migrationBuilder.RenameTable(
                name: "ProductsGroupThirdProducts",
                newName: "ProductsGroupThirdProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsGroupThirdProducts_ProductsGroupThirdId",
                table: "ProductsGroupThirdProduct",
                newName: "IX_ProductsGroupThirdProduct_ProductsGroupThirdId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsGroupThirdProducts_ProductId",
                table: "ProductsGroupThirdProduct",
                newName: "IX_ProductsGroupThirdProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsGroupThirdProduct",
                table: "ProductsGroupThirdProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsGroupThirdProduct_Products_ProductId",
                table: "ProductsGroupThirdProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsGroupThirdProduct_ProductsGroupThird_ProductsGroupThirdId",
                table: "ProductsGroupThirdProduct",
                column: "ProductsGroupThirdId",
                principalTable: "ProductsGroupThird",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
