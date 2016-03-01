using System.Collections.Generic;
using firstaspnet.Data.Entities;

namespace firtaspnet.interfaces.ioc
{
    public interface IRepository<T> where T : EntityBase
    {
       T GiveItem();
       bool Save();
       
    }
}