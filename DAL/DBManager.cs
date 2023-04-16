namespace DAL
{
    internal class DBManager : IDBManager
    {
        private MongoClient client;
        IDietDatabaseSettings dietDatabaseSettings;
        public DBManager(IDietDatabaseSettings dietDatabaseSettings)
        {
            this.dietDatabaseSettings = dietDatabaseSettings;
            this.client = new MongoClient(this.dietDatabaseSettings.ConnectionString);
            
        }
        public IMongoDatabase getDatabase()
        {
            return client.GetDatabase(dietDatabaseSettings.DatabaseName);

        }
    }
}
