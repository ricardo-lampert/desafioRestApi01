using RestApi.Models;
using RestApiTest.TestUtils;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RestApiTest.Tests
{
    public class ProductServiceTest
    {
        private ProductService productService;
        private Utils utils;

        public ProductServiceTest()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "ProductServiceTest")
                .Options;
            var context = new ProductContext(options);

            this.productService = new ProductService(context);
            this.utils = new Utils();
        }

        [Fact]
        public void GetProductMustReturnAllInstances()
        {
            List<Product> expected = utils.InitializeList();
            var actual = productService.GetProducts().ToList();
            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void GetProductMustReturnExpectedInstances()
        {
            List<Product> expected = utils.InitializeList();
            var actual = productService.GetProducts().ToList();
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Id, actual[i].Id);
                Assert.Equal(expected[i].Category, actual[i].Category);
                Assert.Equal(expected[i].Profit, actual[i].Profit);
            }
        }

        [Fact]
        public void GetPriceMustReturnCorrectValue()
        {
            string category = "Bebidas";
            float cost = 25;
            float expected = 32.5f;
            var actual = productService.GetPrice(category, cost);
            Assert.Equal(expected, actual);
            
        }
    }
}