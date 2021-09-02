using System.Collections.Generic;
namespace RestApi.Models
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        float GetPrice(string category, float cost);
    }
}
