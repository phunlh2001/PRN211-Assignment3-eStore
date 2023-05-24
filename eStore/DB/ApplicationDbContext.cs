using eStore.Models;
using Microsoft.EntityFrameworkCore;

namespace eStore.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(o => new
                {
                    o.ProductID,
                    o.OrderID
                });

            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
        }
    }
}