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
    public class CustomerControllerTest
    {
        CustomersController _controller = new CustomersController();

        // CustomerControllerTest() => _controller = new CustomersController();
        
        [Fact]
        public void Get_Returns_All()
        {
            // Act
            var results = _controller.Get() as ActionResult<IEnumerable<Customer>>;
            // Assert                        
            var items = Assert.IsType<ActionResult<IEnumerable<Customer>>>(results);
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
        public void Get_Returns_Correct_Customer()
        {
            // Act
            var results = _controller.Get(3) as ActionResult<Customer>;
            // Assert                        
            Assert.IsType<Customer>(results.Value);
            Assert.Equal(3, results.Value.id);
        }
        [Fact]
        public void Post_Adds_Customer()
        {
            // Act
            var Customer = new Customer {
                id = 0,
                name = "Manny",
            };
            _controller.Post(Customer);
            var results = _controller.Get();

            // Assert                        
            Assert.Equal(4, results.Value.Count());
        }
    }
}
