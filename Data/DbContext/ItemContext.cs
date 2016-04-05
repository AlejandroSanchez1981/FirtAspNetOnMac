using System;
using firstaspnet.Data.Entities;
using firtaspnet.Interfaces.ioc;

namespace firstaspnet.Data.DbContext
{
    public class ItemContext : IRepository<Item>
    {
        public string Name {get; set;}
        
        public Item GiveItem()
        {
            return new Item { Name = "Alf" };
        }

        public bool Save()
        {
            return true;
        }
    }
}