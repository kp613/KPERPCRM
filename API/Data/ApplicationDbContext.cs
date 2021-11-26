using API.Models.AdminModels;
using API.Models.CommonModels;
using API.Models.ProductModels;
using API.Models.ProjectModels;
using API.Models.Setting;
using API.Models.Settings;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class ApplicationDbContext : DbContext   //用于一般数据库（无用户）
    //public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        

        public DbSet<Shareholder> Shareholder { get; set; }
        public DbSet<ShareholderForCompany> ShareholderForCompany { get; set; }
        public DbSet<ShareInvestment> ShareInvestment { get; set; }
        public DbSet<OurCompany> OurCompany { get; set; }
        public DbSet<OurDeliveryAddress> OurDeliveryAddress { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }


        //public DbSet<CommonCategory> CommonCategory { get; set; }
        //public DbSet<CommonSubCategory> CommonSubCategory { get; set; }
        //public DbSet<CommonContent> CommonContent { get; set; }

        public DbSet<Project> Projects { get; set; }

        //public DbSet<Message> Messages { get; set; }
        //public DbSet<AuditAndAuthorization> AuditAndAuthorization { get; set; }
        //public DbSet<ImageUpload> ImageUpload { get; set; }
        //public DbSet<TodoItem> TodoItem { get; set; }

        //public DbSet<BusinessPorfolio> BusinessPorfolio { get; set; }
        //public DbSet<BusinessUserGroup> BusinessUserGroup { get; set; }

        


        //产品相关
        public DbSet<Product> Products { get; set; }
        //public DbSet<ProductComConstant> ProductComConstant { get; set; }
        //public DbSet<ProductComSynonym> ProductComSynonym { get; set; }
        //public DbSet<ProductComUse> ProductComUse { get; set; }
        //public DbSet<ProductComInfo> ProductComInfo { get; set; }
        //public DbSet<ProductUpOrDown> ProductUpOrDown { get; set; }
        //public DbSet<ProductComInstruction> ProductComInstruction { get; set; }

        //public DbSet<ProductUpOrDown> ProductUpOrDowns { get; set; }
        //public DbSet<ProductWithCompany> ProductWithCompany { get; set; }
        //public DbSet<ProductWithNoCasNo> ProductWithNoCasNo { get; set; }

        //public DbSet<ProductCategoryFirst> ProductsGroupFirst { get; set; }
        //public DbSet<ProductCategorySecond> ProductsGroupSecond { get; set; }
        //public DbSet<ProductCategoryThird> ProductsGroupThird { get; set; }
        //public DbSet<ProductsGroupThirdProducts> ProductsGroupThirdProducts { get; set; }

        public DbSet<ProductsControlClass> ProductControlClass { get; set; }
        public DbSet<ProductsNoPublicity> ProductNoPublicity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // use the Fluent API to specify an index on a single column, make an index 
            // https://docs.microsoft.com/en-us/ef/core/modeling/indexes
            modelBuilder.Entity<Product>()
                .HasIndex(x => x.CasNo)
                .IncludeProperties(x => new
                {
                    x.ProductName,
                    x.ProductNameCN
                })     //
                .IsUnique();

            // specify an index over more than one column
            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.ProductName, p.ProductNameCN });

            //modelBuilder.Entity<ProductsGroupThirdProduct>().ToTable("ProductsGroupThirdProducts");

            //modelBuilder.Entity<CommonContent>()
            //       .HasOne(d => d.CommonSubCategory)
            //       .WithMany()
            //       .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<ProductUpOrDown>()
            //       .HasOne(d => d.ProductUp)
            //       .WithMany()
            //       .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<ProductUpOrDown>()
            //       .HasOne(d => d.ProductDown)
            //       .WithMany()
            //       .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<ProductRelevantArray>()
            //       .HasOne(d => d.Product)
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
