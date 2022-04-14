using FarmProducts.Infrastructure.Data;
using FarmProducts.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmProducts.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderProduct>().HasKey(k => new { k.OrderId, k.ProductId });
            builder.Entity<Order>().HasOne(e=>e.Customer).WithMany(e=>e.Orders).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Farm>().HasOne(e=>e.Farmer).WithOne(e=>e.Farm).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Product>().HasOne(e=>e.Farm).WithMany(e=>e.Products).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<OrderProduct>().HasOne(e=>e.Product).WithMany(e=>e.Orders).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<OrderProduct>().HasOne(e=>e.Order).WithMany(e=>e.Products).OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(builder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; } 
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Farmer>? Farmers { get; set; }
        public DbSet<Farm>? Farms { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Day>? Days { get; set; }

    }
}