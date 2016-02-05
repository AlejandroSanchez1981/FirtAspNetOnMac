using System.Collections.Generic;
using firtaspnet.Models;

namespace firtaspnet.Data.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> ListAll();
        void Add(Item item);
    }
}