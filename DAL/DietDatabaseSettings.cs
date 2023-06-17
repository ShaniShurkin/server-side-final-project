namespace DAL
{
    internal class DietDatabaseSettings : IDietDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ClientsCollectionName { get; set; } = null!;
        public string CategoriesCollectionName { get; set; } = null!;
        public string FoodCollectionName { get; set; } = null!;
        public DietDatabaseSettings(Dictionary<string, string> dbsettings)
        {
            try
            {
                ConnectionString = dbsettings["ConnectionString"];
                DatabaseName = dbsettings["DatabaseName"];
                ClientsCollectionName = dbsettings["ClientsCollectionName"];
                CategoriesCollectionName = dbsettings["CategoriesCollectionName"];
                FoodCollectionName = dbsettings["FoodsCollectionName"];
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
    }
}
