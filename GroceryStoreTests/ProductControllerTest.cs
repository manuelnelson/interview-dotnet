using System;
using Xunit;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GroceryStoreTests
{
    public class ProductControllerTest
    {
        ProductsController _controller = new ProductsController();

        // ProductControllerTest() => _controller = new ProductsController();
        
        [Fact]
        public void Get_Returns_All()
        {
            // Act
            var results = _controller.Get() as ActionResult<IEnumerable<Product>>;
            // Assert                        
            var items = Assert.IsType<ActionResult<IEnumerable<Product>>>(results);
            //Assert.Equal(3, results.Value.Count());
        }
        [Fact]
        public void Get_Returns_NotFound()
        {
            // Act
            var results = _controller.Get(6);
            // Assert                        
            Assert.IsType<NotFoundResult>(results.Result);
        }
        [Fact]
        public void Get_Returns_Correct_Product()
        {
            // Act
            var results = _controller.Get(3) as ActionResult<Product>;
            // Assert                        
            Assert.IsType<Product>(results.Value);
            Assert.Equal(3, results.Value.id);
        }
        [Fact]
        public void Post_Adds_Product_Bad_Request()
        {
            // Act
            var product = new Product {
                id = 0,
                description = "",
                price = -1
            };
            var results = _controller.Post(product) as ActionResult<Product>;

            // Assert                        
            Assert.IsType<BadRequestObjectResult>(results.Result);
            //Assert.Equal(4, results.Value.Count());
        }
        [Fact]
        public void Post_Adds_Product()
        {
            // Act
            var product = new Product {
                id = 0,
                description = "",
                price = 2.0
            };
            _controller.Post(product);
            var results = _controller.Get();

            // Assert                        
            Assert.Equal(4, results.Value.Count());
        }
    }
}
