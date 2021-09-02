using System.Collections.Generic;
using System.Linq;
using System;

namespace RestApi.Models
{
    public class ProductService : IProductService
    {
        public readonly ProductContext context;
        public Product product;

        public ProductService(ProductContext context)
        {
            this.product = new Product();
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public float GetPrice(string category, float cost)
        {
            List<Product> products = GetProducts().ToList();
            float profit = product.GetProfit(products, category);
            float value = product.GetValue(cost, profit);
            return value;
        }

    }
}