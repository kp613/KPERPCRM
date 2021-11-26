﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations.WebDb
{
    [DbContext(typeof(WebDbContext))]
    partial class WebDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.ProductModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CasNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNameCN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StructureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDay")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductCategoryFirst", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NameCh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategoryFirsts");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductCategorySecond", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NameCh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductsGroupFirstId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductsGroupFirstId");

                    b.ToTable("ProductCategorySeconds");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductCategoryThird", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AutoGenerate")
                        .HasColumnType("bit");

                    b.Property<string>("KeyElement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyWordCN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyWordEn1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyWordEn2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyWordEn3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyWordEn4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoKeyWordEn1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoKeyWordEn2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoKeyWordEn3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoKeyWordEn4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoKeyWordEn5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrKeyWordEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrKeyWordEn1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrKeyWordEn2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrKeyWordEn3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductCategorySecondId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsGroupSecondId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategorySecondId");

                    b.ToTable("ProductCategoryThirds");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductsInCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsInCategory");
                });

            modelBuilder.Entity("API.Models.WebModels.WebMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActiveDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ApplyingFor")
                        .HasColumnType("bit");

                    b.Property<string>("Auditor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuditorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Finalizer")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MsgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Updatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("WebMessageCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditorId");

                    b.HasIndex("Finalizer");

                    b.HasIndex("PublisherId");

                    b.HasIndex("WebMessageCategoryId");

                    b.ToTable("WebMessage");
                });

            modelBuilder.Entity("API.Models.WebModels.WebMessageCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MsgCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebMessageCategory");
                });

            modelBuilder.Entity("API.Models.WebModels.WebUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebUser");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductCategorySecond", b =>
                {
                    b.HasOne("API.Models.ProductModels.ProductCategoryFirst", "ProductsGroupFirst")
                        .WithMany("ProductsGroupSeconds")
                        .HasForeignKey("ProductsGroupFirstId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductsGroupFirst");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductCategoryThird", b =>
                {
                    b.HasOne("API.Models.ProductModels.ProductCategorySecond", null)
                        .WithMany("ProductsGroupThirds")
                        .HasForeignKey("ProductCategorySecondId");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductsInCategory", b =>
                {
                    b.HasOne("API.Models.ProductModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Models.WebModels.WebMessage", b =>
                {
                    b.HasOne("API.Models.WebModels.WebUser", "WebUserAuditor")
                        .WithMany()
                        .HasForeignKey("AuditorId");

                    b.HasOne("API.Models.WebModels.WebUser", "WebUserFinalizer")
                        .WithMany()
                        .HasForeignKey("Finalizer");

                    b.HasOne("API.Models.WebModels.WebUser", "WebUserPublisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");

                    b.HasOne("API.Models.WebModels.WebMessageCategory", "WebMessageCategory")
                        .WithMany("WebMessages")
                        .HasForeignKey("WebMessageCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WebMessageCategory");

                    b.Navigation("WebUserAuditor");

                    b.Navigation("WebUserFinalizer");

                    b.Navigation("WebUserPublisher");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductCategoryFirst", b =>
                {
                    b.Navigation("ProductsGroupSeconds");
                });

            modelBuilder.Entity("API.Models.ProductModels.ProductCategorySecond", b =>
                {
                    b.Navigation("ProductsGroupThirds");
                });

            modelBuilder.Entity("API.Models.WebModels.WebMessageCategory", b =>
                {
                    b.Navigation("WebMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
