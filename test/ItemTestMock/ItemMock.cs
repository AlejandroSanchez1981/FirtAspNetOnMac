using firtaspnet.interfaces.ioc;

namespace firtaspnet.Test.ItemTestMock
{
    public class ItemTestMock : IRepository<Item>
    {
        private readOnly Func<StreamReader, bool> itemDelegate;
        
        public ItemTestMock(Func<StreamReader, bool> itemDelegate)
        {
            this.itemDelegate = itemDelegate;
        }
        
        
    }
}