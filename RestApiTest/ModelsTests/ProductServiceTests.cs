using RestApi.Models;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RestApiTest.ModelsTests
{
    public class ProductServiceTest
    {
        private ProductService productService;
        public ProductServiceTest()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "ProductListTestService")
                .Options;
            var context = new ProductContext(options);
            this.productService = new ProductService(context);
        }
        [Fact]
        public void GetProductTest()
        {
            List<Product> expected = new List<Product>();
            expected.Add(new Product { Id = 1, Category = "Brinquedos", Profit = 25 });
            expected.Add(new Product { Id = 2, Category = "Bebidas", Profit = 30 });
            expected.Add(new Product { Id = 3, Category = "Informática", Profit = 10 });
            expected.Add(new Product { Id = 4, Category = "Softplan", Profit = 5 });
            var actual = productService.GetProducts().ToList();
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Id, actual[i].Id);
                Assert.Equal(expected[i].Category, actual[i].Category);
                Assert.Equal(expected[i].Profit, actual[i].Profit);
            }
        }
        [Fact]
        public void GetProfitTest()
        {
            string category = "Softplan";
            float expected = 5;
            var actual = productService.GetProfit(category);
            Assert.Equal(expected, actual);
            category = "Ferramentas";
            expected = 15;
            actual = productService.GetProfit(category);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetPriceTest()
        {
            string category = "Bebidas";
            float cost = 25;
            float expected = 32.5f;
            var actual = productService.GetPrice(category, cost);
            Assert.Equal(expected, actual);
            category = "Presentes";
            cost = 200;
            expected = 230;
            actual = productService.GetPrice(category, cost);
            Assert.Equal(expected, actual);
            category = "Materiais escolares";
            cost = 0;
            expected = 0;
            actual = productService.GetPrice(category, cost);
            Assert.Equal(expected, actual);
            category = "Decoração";
            cost = -5;
            expected = 0;
            actual = productService.GetPrice(category, cost);
            Assert.Equal(expected, actual);
        }
    }
}