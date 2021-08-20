using System.Collections.Generic;
using RestApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace RestApi.Controllers
{
    [Route("api01")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(ProductContext context, IProductService service)
        {
            productService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(productService.GetProducts());
        }

        // GET api01/price?category=<category>,cost=<cost>
        [HttpGet("price")]
        public ActionResult<float> GetPrice(string category, float cost)
        {
            return Ok(productService.GetPrice(category, cost));
        }
    }
}
