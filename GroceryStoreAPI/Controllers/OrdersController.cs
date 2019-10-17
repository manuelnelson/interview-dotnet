using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GroceryStoreAPI.Models;
using System;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET api/values
        private List<Order> _model = DbContext.GetContext().orders;

        // GET api/orders?date=2019-10-12
        [HttpGet()]
        public ActionResult<IEnumerable<Order>> Get([FromQuery(Name="date")] DateTime? date)
        {
            if(date.HasValue)
                return _model.Where(x => x.createdDate.Date == date.Value.Date).ToList();
            return _model;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
           var order = _model.FirstOrDefault(x => x.id == id);
           if(order == null || order.id == 0) {
               return NotFound();
           }
           return order;
        }

        // GET api/values/5
        [Route("[action]/{customerId}")]
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Customer(int customerId)
        {
            return _model.Where(x => x.customerId == customerId).ToList();
        }

        // POST api/values
        // [HttpPost]
        // public void Post([FromBody] Order order)
        // {
        //     //get last id
        //     var id = 1;
        //     if(_model.Any()) {
        //        id = _model.OrderByDescending(x => x.id).First().id;
        //     }
        // }

        // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {

        // }

        // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        //     _model = _model.Where(customer => customer.id != id);
        //     return;
        // }
    }
}
