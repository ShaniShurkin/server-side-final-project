namespace DAL
{
    internal class DietDatabaseSettings : IDietDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ClientsCollectionName { get; set; } = null!;
        public string FoodCollectionName { get; set; } = null!;
        public DietDatabaseSettings(string connectionString, string databaseName, string clientsCollectionName, string foodsCollectionName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
            ClientsCollectionName = clientsCollectionName;
            FoodCollectionName = foodsCollectionName;
        }
    }
}
