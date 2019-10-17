using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Models 
{
  public class Order {
    public int id {get;set;}
    public int customerId {get;set;}
    public List<Item> items {get;set;}
    public DateTime createdDate {get;set;}  
  }
  public class Item {
    public int productId {get;set;}
    public int quantity {get;set;}
  }
}

