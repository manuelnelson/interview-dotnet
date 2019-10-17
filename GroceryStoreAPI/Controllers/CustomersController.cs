using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET api/values
        private List<Customer> _model = DbContext.GetContext().customers;

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return this._model;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {            
           var customer = _model.FirstOrDefault(x => x.id == id);
           if(customer == null || customer.id == 0) {
               return NotFound();
           }
           return customer;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            //get last id
            var id = 1;
            if(_model.Any()) {
               id = _model.OrderByDescending(x => x.id).First().id;
            }
            customer.id = ++id;
            this._model.Add(customer);
        }

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
