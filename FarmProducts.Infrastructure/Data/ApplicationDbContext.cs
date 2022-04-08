using FarmProducts.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmProducts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Farmer>? Farmers { get; set; }
        public DbSet<Farm>? Farms { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Day>? Days { get; set; }

    }
}