using System.Collections.Generic;
using System.Linq;

namespace RestApi.Models
{
    public class ProductService : IProductService
    {
        private readonly ProductContext productContext;
        public ProductService(ProductContext productContext)
        {
            this.productContext = productContext;

            if (!productContext.Products.Any())
            {
                productContext.Products.Add(new Product { Category = "Brinquedos", Profit = 25 });
                productContext.Products.Add(new Product { Category = "Bebidas", Profit = 30 });
                productContext.Products.Add(new Product { Category = "Informática", Profit = 10 });
                productContext.Products.Add(new Product { Category = "Softplan", Profit = 5 });
                productContext.SaveChanges();
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            return productContext.Products.ToList();
        }
        public float GetPrice(string category, float cost)
        {
            if (cost <= 0f)
            {
                return 0f;
            }
            float profit = GetProfit(category);
            float value = cost + (cost * (profit / 100f));
            return value;
        }
        public float GetProfit(string category)
        {
            List<Product> products = productContext.Products.Where(i => (i.Category == category)).ToList();
            if (products.Count == 0f)
            {
                return 15f;
            }
            return products[0].Profit;
        }
    }
}