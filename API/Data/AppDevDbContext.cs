using API.Models.AppDevModels.Settings;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{

    //开发过程、使用教程
    public class AppDevDbContext : DbContext
    {
        public AppDevDbContext(DbContextOptions<AppDevDbContext> options)
            : base(options)
        {
        }

        public DbSet<DesignRecord> DesignRecord { get; set; }   //记录软件开发进程



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
