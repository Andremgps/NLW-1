using backend.Extensions;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {
            
        }

        public DbSet<Point> Points { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Point_Item> Point_Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();            

            modelBuilder.Entity<Point_Item>()
                .HasKey(pivot => new { pivot.Point_Id, pivot.Item_Id});                            
            
            modelBuilder.Entity<Point_Item>()
                .HasOne(pivot => pivot.Point)
                .WithMany(point => point.Point_Item)
                .HasForeignKey(pivot => pivot.Point_Id);

            modelBuilder.Entity<Point_Item>()
                .HasOne(pivot => pivot.Item)
                .WithMany(item => item.Point_Item)
                .HasForeignKey(pivot => pivot.Item_Id);                
        }
    }
}