using RestApi.Models;
using System.Collections.Generic;

namespace RestApiTest.TestUtils
{
    public class Utils
    {
        public List<Product> InitializeList()
        {
            List<Product> list = new List<Product>();
            list.Add(new Product { Id = 1, Category = "Brinquedos", Profit = 25 });
            list.Add(new Product { Id = 2, Category = "Bebidas", Profit = 30 });
            list.Add(new Product { Id = 3, Category = "Informática", Profit = 10 });
            list.Add(new Product { Id = 4, Category = "Softplan", Profit = 5 });
            return list;
        }
    }
}
