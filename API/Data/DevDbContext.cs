using API.Models.CustomerModels;
using API.Models.Setting;
using API.Models.WebModels;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class DevDbContext : DbContext
    {
        public DevDbContext(DbContextOptions<DevDbContext> options)
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
