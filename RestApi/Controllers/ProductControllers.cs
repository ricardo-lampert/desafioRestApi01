using System.Collections.Generic;
using RestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    static class Constants
    {
        public const string Route = "api01";
        public const string PriceEndpoint = "price";
    }

    [Route(Constants.Route)]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(ProductContext context, IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(productService.GetProducts());
        }

        [HttpGet(Constants.PriceEndpoint)]
        public ActionResult<float> GetPrice(string category, float cost)
        {
            return Ok(productService.GetPrice(category, cost));
        }
    }
}
