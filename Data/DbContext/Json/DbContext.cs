using System;
using System.Collections.Generic;
using System.IO;
using firstaspnet.Data.Entities;
using firtaspnet.Data.DbContext.Json;
using Newtonsoft.Json;
public class DbContext<T> : IRepository<T> where T : EntityBase
{
    private string conn = "/Users/damivazbien/asp5/firtaspnet/Data/db/json";

    void IRepository<T>.Add(T entity)
    {
        string json = JsonConvert.SerializeObject(entity);
        System.IO.File.WriteAllText (conn + "/" + entity.GetType().Name, json);
    }

    void IRepository<T>.Delete(T entity)
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

    T IRepository<T>.GiveItem()
    {
        StringReader TheStream = new StringReader(conn);
        using (StreamReader r = new StreamReader(TheStream))
        {
            string json = r.ReadToEnd();
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
        }
        
        throw new NotImplementedException();
    }

    IEnumerable<T> IRepository<T>.List()
    {
        throw new NotImplementedException();
    }

}