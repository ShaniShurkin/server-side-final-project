namespace UI
{
    public class DbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string ClientsCollectionName { get; set; }
        public string FoodCollectionName { get; set; }
        //public DbSettings(string connectionString, string databaseName, string clientsCollectionName, string foodsCollectionName)
        //{

        //    ConnectionString = connectionString;
        //    DatabaseName = databaseName;
        //    ClientsCollectionName = clientsCollectionName;
        //    FoodCollectionName = foodsCollectionName;
        //}
    }
}
