using firtaspnet.interfaces.ioc;

namespace firstaspnet.Data.Entities
{
    
    // Here i need inject the depency with dbcontext, for can apply any
    // configuration database.
    public abstract class EntityBase 
    {
        public int Id { get; protected set; }
    }    
}
