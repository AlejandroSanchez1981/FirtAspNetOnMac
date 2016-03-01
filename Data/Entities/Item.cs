using System;
using firtaspnet.interfaces.ioc;

namespace firstaspnet.Data.Entities
{
    public class Item : EntityBase, IRepository<Item>
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