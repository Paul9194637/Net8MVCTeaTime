using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreMVC.Models;
using Oracle.EntityFrameworkCore;


namespace NetCoreMVC.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Category> CATEGORIES { get; set; }
        public DbSet<Product> PRODUCTS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(p => p.ID)
                .UseIdentityColumn();

            modelBuilder.Entity<Product>()
                .Property(p => p.ID)
                .UseIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }

    }
}
