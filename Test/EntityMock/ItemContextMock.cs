using firstaspnet.Data.Entities;
using firtaspnet.Interfaces.ioc;

namespace firstaspnet.Test.EntityMock
{
    public class ItemContextMock : IRepository<Item>
    {
        public bool Save()
        {
            return true;
        }
        
        public Item GiveItem()
        {
            return new Item { Name = "Alf" };
        }
        
        
    }
}