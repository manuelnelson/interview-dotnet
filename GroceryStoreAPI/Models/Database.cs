using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace GroceryStoreAPI.Models 
{
  public class DatabaseContext {
    public List<Customer> customers {get;set;}
    public List<Order> orders {get;set;}
    public List<Product> products {get;set;}
  }
}

