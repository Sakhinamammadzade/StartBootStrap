using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StartBootstrap.Models;

namespace StartBootstrap.Data
{
    public class AppDbContext:IdentityDbContext<M001Users>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Services> Services{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<M001Users>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
