using System.Collections.Generic;
using firstaspnet.Data.Entities;

namespace firtaspnet.Interfaces.ioc
{
    public interface IRepository<T> where T : class
    {
       T GiveItem();
       bool Save();
    }
}