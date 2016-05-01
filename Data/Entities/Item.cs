using System;
using firstaspnet.Models;
using firstaspnet.Interfaces.ioc;
using firstaspnet.Models;

namespace firstaspnet.Data.Entities
{
    public class Item
    {
        public string Name {get; set;}
        public double HowMuch { get; set; }
        
        public Item GiveItem()
        {
            return new Item { Name = "Alf" };
        }

       
    }
    
    public static class ItemModelExtensions
    {
        public static Item ModelToEntity(this ItemModel model)
        {
            var item = new Item{
                Name = model.Name,
                HowMuch = model.HowMuch
            };
     
            return item;
        }
    }
}