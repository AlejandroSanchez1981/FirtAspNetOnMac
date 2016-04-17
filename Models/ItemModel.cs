using System.Collections.Generic;
using System.Linq;
using firstaspnet.Data.Entities;

namespace firstaspnet.Models
{
    public class ItemModel 
    {
        public ItemModel()
        {
           // this.ListItemChildModel = new List<ItemChildModel>();
        }
        public string Name {get; set;}
        public double HowMuch { get; set; }
        
        //public List<ItemChildModel> ListItemChildModel {get; set;}
    }
    
    public class ItemChildModel
    {
        public string Name { get; set; }
    }
    public static class ItemModelExtensions
    {
        public static ItemModel ModelToEntity(this Item source)
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