using System;
using System.Collections.Generic;
using firtaspnet.interfaces.ioc;

namespace firstaspnet.Data
{
    public class Item : IRepository
    {
        
        public string Name {get; set;}

        public Item GiveItem()
        {
            return new Item { Name = "AlfBOCA1905" };
        }

       
    }
}