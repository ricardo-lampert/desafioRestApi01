using RestApi.Controllers;
using RestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
namespace RestApiTest.ControlerTests
{
    public class ProductControllerTest
    {
        private ProductController productController;

        public ProductControllerTest()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "ProductListController")
                .Options;
            var context = new ProductContext(options);
            var productService = new ProductService(context);
            this.productController = new ProductController(context, productService);
        }
        [Fact]
        public void GetProductTest()
        {
            List<Product> expected = new List<Product>();
            expected.Add(new Product { Id = 1, Category = "Brinquedos", Profit = 25 });
            expected.Add(new Product { Id = 2, Category = "Bebidas", Profit = 30 });
            expected.Add(new Product { Id = 3, Category = "Informática", Profit = 10 });
            expected.Add(new Product { Id = 4, Category = "Softplan", Profit = 5 });
            var result = productController.GetProducts().Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<List<Product>>(result.Value);
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Id, actual[i].Id);
                Assert.Equal(expected[i].Category, actual[i].Category);
                Assert.Equal(expected[i].Profit, actual[i].Profit);
            }
        }
        [Fact]
        public void GetPriceTest()
        {
            string category = "Informática";
            float cost = 40;
            float expected = 44;
            var result = productController.GetPrice(category, cost).Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<float>(result.Value);
            Assert.Equal(expected, actual);
            category = "Limpeza";
            cost = 100;
            expected = 115;
            result = productController.GetPrice(category, cost).Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            actual = Assert.IsType<float>(result.Value);
            Assert.Equal(expected, actual);
            category = "Brinquedos";
            cost = 0;
            expected = 0;
            result = productController.GetPrice(category, cost).Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            actual = Assert.IsType<float>(result.Value);
            Assert.Equal(expected, actual);
            category = "Softplan";
            cost = -30.25f;
            expected = 0;
            result = productController.GetPrice(category, cost).Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            actual = Assert.IsType<float>(result.Value);
            Assert.Equal(expected, actual);
        }
    }
}