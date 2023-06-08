using Microsoft.Extensions.DependencyInjection;
namespace DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection collection, Dictionary<string, string> dbsettings)
        {
            collection.AddSingleton<IDietDatabaseSettings>(new DietDatabaseSettings(dbsettings));
            collection.AddSingleton<IDBManager, DBManager>();
            collection.AddSingleton<IFoodRepository, FoodRepository>();
            collection.AddSingleton<IClientRepository, ClientRepository>();
            collection.AddSingleton<IMenuRepository, MenuRepository>();

            return collection;
        }
    }
}
