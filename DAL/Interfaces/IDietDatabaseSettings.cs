namespace DAL.Interfaces
{
    public interface IDietDatabaseSettings
    {
        string ClientsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string FoodCollectionName { get; set; }
        string CategoriesCollectionName { get; set; }
    }
}