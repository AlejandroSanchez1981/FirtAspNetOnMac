using System.Collections.Generic;
using System.Linq;
using firstaspnet.Data.Entities;

namespace firtaspnet.Models
{
    public class ItemModel 
    {
        public string Name {get; set;}
    }
    
    
    public static class ItemModelExtensions
    {
        public static ItemModel ToItemModel(this Item source)
        {
            if(source == null)
            {
                return null;
            }
            return new ItemModel
            {
              Name = source.Name  
            };
        }
    }
}