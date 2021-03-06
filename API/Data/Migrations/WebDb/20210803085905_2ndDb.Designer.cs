// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations.WebDb
{
    [DbContext(typeof(AppWebDbContext))]
    [Migration("20210803085905_2ndDb")]
    partial class _2ndDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.WebModels.ProductPublishing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CASNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNameCN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductPublishing");
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

            modelBuilder.Entity("API.Models.WebModels.WebMessageCategory", b =>
                {
                    b.Navigation("WebMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
