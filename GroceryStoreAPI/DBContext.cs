using GroceryStoreAPI.Models;
using System.Text.Json;

namespace GroceryStoreAPI {

  public static class DbContext {

    private static DatabaseContext _context {get;set;}
    public static DatabaseContext GetContext() {
      if(_context != null)
        return _context;

      var json = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/database.json");
      _context = JsonSerializer.Deserialize<DatabaseContext>(json);
      return _context;
    }
  }
}
