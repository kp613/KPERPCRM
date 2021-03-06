// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.data.migrations.applicationdb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.ApplicationModels.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CasNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductNameCN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StructureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDay")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CasNo")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Include", new[] { "ProductName", "ProductNameCN" });

                    b.HasIndex("ProductName", "ProductNameCN");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.Models.ApplicationModels.Settings.OurCompany", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Constitution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JuridicalPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherInf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PaidInCapital")
                        .HasColumnType("float");

                    b.Property<string>("RegAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RegisteredCapital")
                        .HasColumnType("float");

                    b.Property<string>("ServiceFeature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ShareTotal")
                        .HasColumnType("float");

                    b.Property<string>("StockComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwiftCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UsedAsBusiness")
                        .HasColumnType("bit");

                    b.Property<bool>("UsedAsShare")
                        .HasColumnType("bit");

                    b.Property<string>("Web")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OurCompany");
                });
#pragma warning restore 612, 618
        }
    }
}
