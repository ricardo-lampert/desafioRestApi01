using RestApi.Models;
using RestApiTest.TestUtils;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace RestApiTest.Tests
{
    public class ProductTest
    {
        private Product product;
        private Utils utils;

        public ProductTest()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "ProductTest")
                .Options;
            var context = new ProductContext(options);
            this.product = new Product();
            this.utils = new Utils();
        }

        [Fact]
        public void GetProfitMustReturnCorrectValue()
        {
            List<Product> products = utils.InitializeList();
            string category = "Softplan";
            float expected = 5;
            var actual = product.GetProfit(products, category);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProfitMustReturnDefaultValue()
        {
            List<Product> products = new List<Product>();
            string category = "Comidas";
            float expected = 15;
            var actual = product.GetProfit(products, category);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetValueMustReturnCorrectValue()
        {
            float cost = 200;
            float profit = 15;
            float expected = 230;
            var actual = product.GetValue(cost, profit);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GetValueMustReturnZeroBecauseCostZero()
        {
            float cost = 0;
            float profit = 125;
            float expected = 0;
            var actual = product.GetValue(cost, profit);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetValueMustReturnZeroBecauseCostNegative()
        {
            float cost = -10;
            float profit = 50;
            float expected = 0;
            var actual = product.GetValue(cost, profit);
            Assert.Equal(expected, actual);
        }
    }
}