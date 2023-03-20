using Microsoft.Extensions.DependencyInjection;
namespace BL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection collection,string ConnectionString, string DatabaseName, string ClientsCollectionName, string FoodsCollectionName)
        {
            collection.AddSingleton<IClientService, ClientService>();
            collection.AddSingleton<IFoodService, FoodService>();
            collection.AddRepositories(ConnectionString, DatabaseName, ClientsCollectionName, FoodsCollectionName);
            return collection;
        }
    }
}
