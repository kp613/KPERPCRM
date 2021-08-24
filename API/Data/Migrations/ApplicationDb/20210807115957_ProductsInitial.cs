using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.data.migrations.applicationdb
{
    public partial class ProductsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OurCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JuridicalPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredCapital = table.Column<double>(type: "float", nullable: false),
                    PaidInCapital = table.Column<double>(type: "float", nullable: false),
                    ShareTotal = table.Column<double>(type: "float", nullable: false),
                    ServiceFeature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Web = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Constitution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurDeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurDeliveryAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductControlClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionSell = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ClassThirdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductControlClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsGroupFirst",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NameCh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsGroupFirst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PayPeriod = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shareholder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OurCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shareholder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shareholder_OurCompany_OurCompanyId",
                        column: x => x.OurCompanyId,
                        principalTable: "OurCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductNameCN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StructureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductControlClass_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductControlClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsGroupSecond",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductsGroupFirstId = table.Column<int>(type: "int", nullable: false),
                    NameCh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsGroupSecond", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsGroupSecond_ProductsGroupFirst_ProductsGroupFirstId",
                        column: x => x.ProductsGroupFirstId,
                        principalTable: "ProductsGroupFirst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShareholderForCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OurCompanyId = table.Column<int>(type: "int", nullable: false),
                    ShareholderId = table.Column<int>(type: "int", nullable: false),
                    SubscribedStock = table.Column<double>(type: "float", nullable: false),
                    SubscribedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareholderForCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShareholderForCompany_OurCompany_OurCompanyId",
                        column: x => x.OurCompanyId,
                        principalTable: "OurCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShareholderForCompany_Shareholder_ShareholderId",
                        column: x => x.ShareholderId,
                        principalTable: "Shareholder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShareInvestment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OurCompanyId = table.Column<int>(type: "int", nullable: false),
                    ShareholderId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidIn = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    ShareConvert = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    GiveShare = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registrant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShareOption = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    GetShareDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareInvestment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShareInvestment_OurCompany_OurCompanyId",
                        column: x => x.OurCompanyId,
                        principalTable: "OurCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShareInvestment_Shareholder_ShareholderId",
                        column: x => x.ShareholderId,
                        principalTable: "Shareholder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComConstant",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MolecularFormula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MolecularWeight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComConstant", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductComConstant_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComInfo",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QuoteSuggest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComInfo", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductComInfo_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComInstruction",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComInstruction", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductComInstruction_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComSynonym",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SynonymsEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SynonymsCN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComSynonym", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductComSynonym_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComUse",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UseInEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseInCh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComUse", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductComUse_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductNoPublicity",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TypeForControl = table.Column<int>(type: "int", nullable: false),
                    IsException = table.Column<bool>(type: "bit", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettleMan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNoPublicity", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductNoPublicity_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductUpOrDown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UpOrDown = table.Column<bool>(type: "bit", nullable: false),
                    UpOrDownId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUpOrDown", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductUpOrDown_Products_UpOrDownId",
                        column: x => x.UpOrDownId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsGroupThird",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsGroupSecondId = table.Column<int>(type: "int", nullable: false),
                    NameCh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoGenerate = table.Column<bool>(type: "bit", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyElement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyWordCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyWordEn1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyWordEn2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyWordEn3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyWordEn4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrKeyWordEn1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrKeyWordEn2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrKeyWordEn3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrKeyWordEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKeyWordEn1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKeyWordEn2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKeyWordEn3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKeyWordEn4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKeyWordEn5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassThirdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsGroupThird", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsGroupThird_ProductControlClass_ClassThirdId",
                        column: x => x.ClassThirdId,
                        principalTable: "ProductControlClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsGroupThird_ProductsGroupSecond_ProductsGroupSecondId",
                        column: x => x.ProductsGroupSecondId,
                        principalTable: "ProductsGroupSecond",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsGroupThirdProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsGroupThirdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsGroupThirdProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsGroupThirdProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsGroupThirdProduct_ProductsGroupThird_ProductsGroupThirdId",
                        column: x => x.ProductsGroupThirdId,
                        principalTable: "ProductsGroupThird",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CasNo",
                table: "Products",
                column: "CasNo",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "ProductName", "ProductNameCN" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName_ProductNameCN",
                table: "Products",
                columns: new[] { "ProductName", "ProductNameCN" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupSecond_ProductsGroupFirstId",
                table: "ProductsGroupSecond",
                column: "ProductsGroupFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupThird_ClassThirdId",
                table: "ProductsGroupThird",
                column: "ClassThirdId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupThird_ProductsGroupSecondId",
                table: "ProductsGroupThird",
                column: "ProductsGroupSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupThirdProduct_ProductId",
                table: "ProductsGroupThirdProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupThirdProduct_ProductsGroupThirdId",
                table: "ProductsGroupThirdProduct",
                column: "ProductsGroupThirdId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUpOrDown_UpOrDownId",
                table: "ProductUpOrDown",
                column: "UpOrDownId");

            migrationBuilder.CreateIndex(
                name: "IX_Shareholder_OurCompanyId",
                table: "Shareholder",
                column: "OurCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareholderForCompany_OurCompanyId",
                table: "ShareholderForCompany",
                column: "OurCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareholderForCompany_ShareholderId",
                table: "ShareholderForCompany",
                column: "ShareholderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareInvestment_OurCompanyId",
                table: "ShareInvestment",
                column: "OurCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareInvestment_ShareholderId",
                table: "ShareInvestment",
                column: "ShareholderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurDeliveryAddress");

            migrationBuilder.DropTable(
                name: "ProductComConstant");

            migrationBuilder.DropTable(
                name: "ProductComInfo");

            migrationBuilder.DropTable(
                name: "ProductComInstruction");

            migrationBuilder.DropTable(
                name: "ProductComSynonym");

            migrationBuilder.DropTable(
                name: "ProductComUse");

            migrationBuilder.DropTable(
                name: "ProductNoPublicity");

            migrationBuilder.DropTable(
                name: "ProductsGroupThirdProduct");

            migrationBuilder.DropTable(
                name: "ProductUpOrDown");

            migrationBuilder.DropTable(
                name: "ShareholderForCompany");

            migrationBuilder.DropTable(
                name: "ShareInvestment");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "ProductsGroupThird");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shareholder");

            migrationBuilder.DropTable(
                name: "ProductsGroupSecond");

            migrationBuilder.DropTable(
                name: "ProductControlClass");

            migrationBuilder.DropTable(
                name: "OurCompany");

            migrationBuilder.DropTable(
                name: "ProductsGroupFirst");
        }
    }
}
