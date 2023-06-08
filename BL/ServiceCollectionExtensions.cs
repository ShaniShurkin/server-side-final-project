using BL.Interfaces;

using Microsoft.Extensions.DependencyInjection;
namespace BL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection collection, Dictionary<string, string> dbsettings)
        {
            collection.AddSingleton<IClientService, ClientService>();
            collection.AddSingleton<IFoodService, FoodService>();
            collection.AddSingleton<IMenuService, MenuService>();
            collection.AddRepositories(dbsettings);
            collection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //collection.AddAutoMapper(typeof(ClientProfile));
            return collection;
        }
    }
}
