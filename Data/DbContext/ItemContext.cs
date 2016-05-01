using System;
using firstaspnet.Data.Entities;
using firstaspnet.Interfaces.ioc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace firstaspnet.Data.DbContext
{
    public class ItemContext : IRepository<Item>
    {
        public string Name {get; set;}
        
        public Item GiveItem()
        {
            return new Item { Name = "Alf" };
        }

        public Item GiveMonthPrevius()
        {
            throw new NotImplementedException();
        }

        public bool Save(Item entity)
        {
            return true;
        }
    }

}


