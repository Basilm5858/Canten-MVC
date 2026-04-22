using Microsoft.EntityFrameworkCore;

namespace Canteen_Order_Management_System.Models
{
    public class My_AppContext : DbContext
    {
        public My_AppContext(DbContextOptions<My_AppContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.FoodItem)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.FoodItemId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Staff)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.StaffId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
