namespace DAL.Interfaces
{
    public interface IDBManager
    {
        public IMongoDatabase getDatabase();
    }
}
