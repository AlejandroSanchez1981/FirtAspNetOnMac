using System.Collections.Generic;

namespace firtaspnet.Data.DbContext.Json
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> List();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        T GiveItem();
    }    
}


