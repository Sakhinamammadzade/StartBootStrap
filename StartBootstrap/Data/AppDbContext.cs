using Microsoft.EntityFrameworkCore;
using StartBootstrap.Models;

namespace StartBootstrap.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Services> Services{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
      
    }
}
