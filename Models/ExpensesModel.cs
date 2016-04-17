using System.Collections.Generic;

namespace firstaspnet.Models
{
    public class ExpensesModel
    {
      public ExpensesModel()
      {
          ListItemsExpenseModel = new List<ItemModel>();
      }
      public List<ItemModel> ListItemsExpenseModel { get; set; }
    }    
}
