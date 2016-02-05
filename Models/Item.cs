using System.Collections.Generic;
using System.Linq;
using firtaspnet.Data.Interface;

namespace firtaspnet.Models
{
    public class Item : IItemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        
        public Item(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<Item> ListAll()
        {
            return _dbContext.Item.AsEnumerable();
        }

        public void Add(Item item)
        {
            _dbContext.Item.Add(item);
            _dbContext.SaveChanges();
        }
    }
}