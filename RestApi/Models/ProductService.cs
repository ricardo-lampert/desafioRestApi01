using System.Collections.Generic;
using System.Linq;

namespace RestApi.Models
{
    public class ProductService : IProductService
    {
        private readonly ProductContext context;
        public ProductService(ProductContext context)
        {
            this.context = InitializeContext(context);
        }

        private ProductContext InitializeContext(ProductContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Product { Category = "Brinquedos", Profit = 25 });
                context.Products.Add(new Product { Category = "Bebidas", Profit = 30 });
                context.Products.Add(new Product { Category = "Informática", Profit = 10 });
                context.Products.Add(new Product { Category = "Softplan", Profit = 5 });
                context.SaveChanges();
            }
            return context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
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
            List<Product> products = context.Products.Where(i => (i.Category == category)).ToList();
            if (products.Count == 0f)
            {
                return 15f;
            }
            return products[0].Profit;
        }


    }
}