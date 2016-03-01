using firtaspnet.Data.DbContext.Json;

namespace firstaspnet.Data.Entities
{
    
    // Here i need inject the depency with dbcontext, for can apply any
    // configuration database.
    public abstract class EntityBase 
    {
        public IRepository<EntityBase> entity;
        
        public EntityBase(IRepository<EntityBase> entity)
        {
            this.entity = entity;
        }
        
        
        public int Id { get; protected set; }
    }    
}
