using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data
{
    public class ProductServiceDbContext : DbContext
    {
        public ProductServiceDbContext(DbContextOptions<ProductServiceDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}
