using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET api/values
        private List<Product> _model = DbContext.GetContext().products;

        // [HttpGet]
        // public ActionResult<IEnumerable<Order>> Get()
        // {
        //     return this._model;
        // }

        // GET api/products
        [HttpGet()]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _model;
        }
        
        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {            
           var product = _model.FirstOrDefault(x => x.id == id);
           if(product == null || product.id == 0) {
               return NotFound();
           }
           return product;
        }

        // POST api/products
        [HttpPost]   
        public ActionResult<Product> Post([FromBody] Product product)
        {
            //validation
            if(product.price <= 0) {
                return BadRequest("Price must be greater than 0");
            }
            //get last id
            var id = 1;
            if(_model.Any()) {
               id = _model.OrderByDescending(x => x.id).First().id;
            }
            product.id = ++id;
            this._model.Add(product);
            return product;
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
