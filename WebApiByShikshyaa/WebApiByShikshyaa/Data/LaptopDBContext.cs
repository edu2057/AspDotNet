using Microsoft.EntityFrameworkCore;
using WebApiByShikshyaa.Models;

namespace WebApiByShikshyaa.Data
{
    public class LaptopDbContext : DbContext
    {
        public LaptopDbContext(DbContextOptions<LaptopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>(entity =>
            {
                entity.HasKey(e => e.Id);  // Set Id as the primary key
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
