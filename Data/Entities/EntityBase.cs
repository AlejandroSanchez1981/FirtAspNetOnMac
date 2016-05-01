using System;
using firstaspnet.Interfaces.ioc;

namespace firstaspnet.Data.Entities
{
    
    // Here i need inject the depency with dbcontext, for can apply any
    // configuration database.
    public abstract class EntityBase 
    {
        public Guid Id { get; set; }
    }    
}
