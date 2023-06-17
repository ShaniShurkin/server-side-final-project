namespace DAL
{
    internal class DBManager : IDBManager
    {
        private MongoClient client;
        IDietDatabaseSettings dietDatabaseSettings;
        public DBManager(IDietDatabaseSettings dietDatabaseSettings)
        {
            try
            {
                this.dietDatabaseSettings = dietDatabaseSettings;
                this.client = new MongoClient(this.dietDatabaseSettings.ConnectionString);
            }
            catch (MongoConnectionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IMongoDatabase getDatabase()
        {
            try
            {
                return client.GetDatabase(dietDatabaseSettings.DatabaseName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
