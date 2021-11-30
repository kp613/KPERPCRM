using API.Models.AppCoreModels;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    //用于记录股东信息、财务信息
    public class AppCoreDbContext : DbContext
    {
        public AppCoreDbContext(DbContextOptions<AppDevDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shareholder> Shareholder { get; set; }
        public DbSet<ShareholderForCompany> ShareholderForCompany { get; set; }
        public DbSet<ShareInvestment> ShareInvestment { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
