namespace firtaspnet.Interfaces.ioc
{
    public interface IRepository<T> where T : class
    {
       T GiveItem();
       bool Save(T entity);
       T GiveMonthPrevius();
    }
}