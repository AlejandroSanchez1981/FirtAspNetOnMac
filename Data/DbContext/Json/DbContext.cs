using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public class DbContext<T> : IRepository<T> where T : EntityBase
{
    private string conn = "rute where save the files";

    void IRepository<T>.Add(T entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<T>.Add(T entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<T>.Delete(T entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<T>.Delete(T entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<T>.Edit(T entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<T>.Edit(T entity)
    {
        throw new NotImplementedException();
    }

    T IRepository<T>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    T IRepository<T>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    IEnumerable<T> IRepository<T>.List()
    {
        throw new NotImplementedException();
    }

    IEnumerable<T> IRepository<T>.List()
    {
        throw new NotImplementedException();
    }

    IEnumerable<T> IRepository<T>.List(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    IEnumerable<T> IRepository<T>.List(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}