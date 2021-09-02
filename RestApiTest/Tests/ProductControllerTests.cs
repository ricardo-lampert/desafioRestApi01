using RestApi.Controllers;
using RestApi.Models;
using RestApiTest.TestUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace RestApiTest.Tests
{

    public class ProductControllerTest
    {
        private ProductController productController;
        private Utils utils;

        public ProductControllerTest()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "ProductControllerTest")
                .Options;
            var context = new ProductContext(options);
            var product = new ProductService(context);

            this.productController = new ProductController(context, product);
            this.utils = new Utils();
        }

        [Fact]
        public void GetProductMustReturnOK()
        {
            List<Product> expected = utils.InitializeList();
            var result = productController.GetProducts().Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetProductMustReturnListOfProducts()
        {
            List<Product> expected = utils.InitializeList();
            var result = productController.GetProducts().Result as OkObjectResult;
            Assert.IsType<List<Product>>(result.Value);
        }

        [Fact]
        public void GetPriceMustReturnOK()
        {
            string category = "Informática";
            float cost = 40;
            var result = productController.GetPrice(category, cost).Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void GetPriceMustReturnFloat()
        {
            string category = "Informática";
            float cost = 40;
            var result = productController.GetPrice(category, cost).Result as OkObjectResult;
            Assert.IsType<float>(result.Value);
        }
    }
}