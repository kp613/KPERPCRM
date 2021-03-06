using API.Models.AppIdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    //public class AppIdentityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int,IdentityUserClaim<int>,ApplicationUserRole,IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    public class AppIdentityDbContext : IdentityDbContext
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        //public DbSet<ApplicationUserRole> AspNetUserRoles { get; set; }

        //public DbSet<Photo> Photos { get; set; }
        public DbSet<Message> Messages { get; set; }


        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<ApplicationUser>()
            //    .HasMany(ur => ur.UserRoles)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(ur => ur.UserId)
            //    .IsRequired();

            //builder.Entity<ApplicationRole>()
            //    .HasMany(ur => ur.UserRoles)
            //    .WithOne(u => u.Role)
            //    .HasForeignKey(ur => ur.RoleId)
            //    .IsRequired();

            //builder.Entity<UserLike>()
            //   .HasKey(k => new { k.SourceUserId, k.LikedUserId });

            //builder.Entity<UserLike>()
            //    .HasOne(s => s.SourceUser)
            //    .WithMany(l => l.LikedUsers)
            //    .HasForeignKey(s => s.SourceUserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<UserLike>()
            //    .HasOne(s => s.LikedUser)
            //    .WithMany(l => l.LikedByUsers)
            //    .HasForeignKey(s => s.LikedUserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);


            //builder.Entity<ProductListInType>()
            //    .HasMany(x => x.ProductTypes)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ProductListInType>()
            //    .HasMany(x => x.Products)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
