namespace DAL
{
    internal class DBManager : IDBManager
    {
        private MongoClient client;
        public DBManager(string connectionString)
        {
            this.client = new MongoClient(connectionString);
        }
        public MongoClient getDatabase()
        {
            return client;
           
        }
    }
}
