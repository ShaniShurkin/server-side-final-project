namespace DAL
{
    public interface IDietDatabaseSettings
    {
        string ClientsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string FoodCollectionName { get; set; }
    }
}