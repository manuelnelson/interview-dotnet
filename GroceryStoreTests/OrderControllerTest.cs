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
    public class OrderControllerTest
    {
        OrdersController _controller = new OrdersController();
        [Fact]
        public void Get_Returns_All()
        {
            // Act
            var results = _controller.Get(null) as ActionResult<IEnumerable<Order>>;
            // Assert                        
            var items = Assert.IsType<ActionResult<IEnumerable<Order>>>(results);
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
        public void Get_Orders_By_Date()
        {
            // Act
            var results = _controller.Get(new DateTime(2019,10,16)) as ActionResult<IEnumerable<Order>>;
            // Assert                        
            Assert.IsType<List<Order>>(results.Value);
        }
        [Fact]
        public void Get_Orders_By_Date_Empty()
        {
            // Act
            var results = _controller.Get(new DateTime(2019,10,15)) as ActionResult<IEnumerable<Order>>;
            // Assert                        
            Assert.Equal(0, results.Value.Count());
        }
        [Fact]
        public void Get_Orders_By_Customer_Id()
        {
            // Act
            var results = _controller.Customer(1) as ActionResult<IEnumerable<Order>>;
            // Assert                        
            Assert.IsType<List<Order>>(results.Value);
        }
        [Fact]
        public void Get_Returns_Correct_Order()
        {
            // Act
            var results = _controller.Get(1) as ActionResult<Order>;
            // Assert                        
            Assert.IsType<Order>(results.Value);
            Assert.Equal(1, results.Value.id);
        }
        // [Fact]
        // public async void Post_Adds_Order()
        // {
        //     // Act
        //     var Order = new Order {
        //         id = 0,
        //         description = "",
        //         price = 2.0
        //     };
        //     _controller.Post(Order);
        //     var results = _controller.Get();

        //     // Assert                        
        //     Assert.Equal(4, results.Value.Count());
        // }
    }
}
