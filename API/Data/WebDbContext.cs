using API.Models.WebModels;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductPublishing> ProductPublishing { get; set; }

        public DbSet<WebUser> WebUser { get; set; }
        public DbSet<WebMessageCategory> WebMessageCategory { get; set; }
        public DbSet<WebMessage> WebMessage { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<WebMessage>()
            //       .HasOne(d => d.WebMessageCategory)
            //       .WithMany()
            //       .OnDelete(DeleteBehavior.Restrict);



            //modelBuilder.Entity<ProductConnectUpAndDown>()
            //    .HasKey(c => new { c.ProductFirstId, c.ProductFirstSecondId });    //添加了主键

            //modelBuilder.Entity<ProductRelevantArray>()
            //    .HasKey(c => new { c.ProductId });                               //添加了主键

            //modelBuilder.Entity<ApplicationUser>(b =>
            //{
            //    // Each User can have many UserClaims
            //    b.HasMany(e => e.Claims)
            //        .WithOne()
            //        .HasForeignKey(uc => uc.UserId)
            //        .IsRequired();

            //    // Each User can have many UserLogins
            //    b.HasMany(e => e.Logins)
            //        .WithOne()
            //        .HasForeignKey(ul => ul.UserId)
            //        .IsRequired();

            //    // Each User can have many UserTokens
            //    b.HasMany(e => e.Tokens)
            //        .WithOne()
            //        .HasForeignKey(ut => ut.UserId)
            //        .IsRequired();

            //    // Each User can have many entries in the UserRole join table
            //    b.HasMany(e => e.UserRoles)
            //        .WithOne()
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();
            //});

            //modelBuilder.Entity<ApplicationRole>(b =>
            //{
            //    // Each Role can have many entries in the UserRole join table
            //    b.HasMany(e => e.UserRoles)
            //        .WithOne(e => e.Role)
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();

            //    // Each Role can have many associated RoleClaims
            //    b.HasMany(e => e.RoleClaims)
            //        .WithOne(e => e.Role)
            //        .HasForeignKey(rc => rc.RoleId)
            //        .IsRequired();
            //});

            //    modelBuilder.Entity<CommonCategory>().ToTable("CommonCategory");
            //    modelBuilder.Entity<CommonSubCategory>().ToTable("CommonSubCategory");            
            //    modelBuilder.Entity<CommonContent>().ToTable("CommonContent");


            //    modelBuilder.Entity<Instructor>().HasBaseType<Person>();
            //    modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            //    modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            //    modelBuilder.Entity<Person>().ToTable("Person");
            //    modelBuilder.Entity<Student>().HasBaseType<Person>();
            //    modelBuilder.Entity<CourseAssignment>()
            //        .HasKey(c => new { c.CourseID, c.InstructorID });

        }

    }
}
