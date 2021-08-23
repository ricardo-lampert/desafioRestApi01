using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {  
        }
    }
}