using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations.WebDb
{
    public partial class addCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    AreaNameCh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceForCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InquiryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceForCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductNameCN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StructureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNameCh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAbandoned = table.Column<bool>(type: "bit", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    CustomerWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyQQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWeChat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificateMan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
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
                        name: "FK_ProductComConstant_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
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
                        name: "FK_ProductComInfo_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
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
                        name: "FK_ProductComInstruction_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
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
                        name: "FK_ProductComSynonym_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
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
                        name: "FK_ProductComUse_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
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
                        name: "FK_ProductUpOrDown_Product_UpOrDownId",
                        column: x => x.UpOrDownId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "CustomerAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ContacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Area_CityId",
                        column: x => x.CityId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customers_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankSwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCanceled = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerBank_Customers_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContacter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeChat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDimission = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContacter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerContacter_Customers_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRelateAnother",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerRelateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRelateAnother", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerRelateAnother_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
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
                    NoKeyWordEn5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsGroupThird", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsGroupThird_ProductsGroupSecond_ProductsGroupSecondId",
                        column: x => x.ProductsGroupSecondId,
                        principalTable: "ProductsGroupSecond",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inquiry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyContacterId = table.Column<int>(type: "int", nullable: false),
                    InquireContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquireTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeIn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiry_CustomerContacter_CompanyContacterId",
                        column: x => x.CompanyContacterId,
                        principalTable: "CustomerContacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inquiry_Customers_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsGroupThirdProducts",
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
                    table.PrimaryKey("PK_ProductsGroupThirdProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsGroupThirdProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsGroupThirdProducts_ProductsGroupThird_ProductsGroupThirdId",
                        column: x => x.ProductsGroupThirdId,
                        principalTable: "ProductsGroupThird",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InquiriedProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InquiryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InquiryStatus = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceForCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiriedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquiriedProduct_Inquiry_InquiryId",
                        column: x => x.InquiryId,
                        principalTable: "Inquiry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InquiriedProduct_PriceForCustomer_PriceForCustomerId",
                        column: x => x.PriceForCustomerId,
                        principalTable: "PriceForCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InquiriedProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CityId",
                table: "CustomerAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CompanyId",
                table: "CustomerAddress",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBank_CompanyId",
                table: "CustomerBank",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacter_CompanyId",
                table: "CustomerContacter",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AreaId",
                table: "Customers",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InquiriedProduct_InquiryId",
                table: "InquiriedProduct",
                column: "InquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_InquiriedProduct_PriceForCustomerId",
                table: "InquiriedProduct",
                column: "PriceForCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InquiriedProduct_ProductId",
                table: "InquiriedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiry_CompanyContacterId",
                table: "Inquiry",
                column: "CompanyContacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiry_CompanyId",
                table: "Inquiry",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupSecond_ProductsGroupFirstId",
                table: "ProductsGroupSecond",
                column: "ProductsGroupFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupThird_ProductsGroupSecondId",
                table: "ProductsGroupThird",
                column: "ProductsGroupSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupThirdProducts_ProductId",
                table: "ProductsGroupThirdProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupThirdProducts_ProductsGroupThirdId",
                table: "ProductsGroupThirdProducts",
                column: "ProductsGroupThirdId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUpOrDown_UpOrDownId",
                table: "ProductUpOrDown",
                column: "UpOrDownId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "CustomerBank");

            migrationBuilder.DropTable(
                name: "CustomerRelateAnother");

            migrationBuilder.DropTable(
                name: "InquiriedProduct");

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
                name: "ProductsGroupThirdProducts");

            migrationBuilder.DropTable(
                name: "ProductUpOrDown");

            migrationBuilder.DropTable(
                name: "Inquiry");

            migrationBuilder.DropTable(
                name: "PriceForCustomer");

            migrationBuilder.DropTable(
                name: "ProductsGroupThird");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "CustomerContacter");

            migrationBuilder.DropTable(
                name: "ProductsGroupSecond");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductsGroupFirst");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
