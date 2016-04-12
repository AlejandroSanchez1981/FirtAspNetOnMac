namespace firstaspnet.Data.Db
{
    public interface IStorageInitializer
	{
		void Initialize();
		void Drop();
	}    
}
