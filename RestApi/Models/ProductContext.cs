using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            InitializeContext();
        }

        private void InitializeContext()
        {
            if (!Products.Any())
            {
                Products.Add(new Product { Category = "Brinquedos", Profit = 25 });
                Products.Add(new Product { Category = "Bebidas", Profit = 30 });
                Products.Add(new Product { Category = "Informática", Profit = 10 });
                Products.Add(new Product { Category = "Softplan", Profit = 5 });
                SaveChanges();
            }
        }

    }
}