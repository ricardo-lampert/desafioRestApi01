using System.Collections.Generic;
using System.Linq;

namespace RestApi.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public float Profit { get; set; }

        public float GetProfit(List<Product> products, string category)
        {
            foreach(Product product in products)
            {
                if (product.Category.Equals(category))
                {
                    return product.Profit;
                }
            }
            return 15f;
        }

        public float GetValue(float cost,float profit)
        {
            if (cost<=0)
            {
                return 0;
            }
            float value = cost + (cost * (profit / 100f));
            return value;
        }
        
    }
}