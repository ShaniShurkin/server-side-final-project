using Microsoft.Extensions.DependencyInjection;
namespace DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection collection, string ConnectionString, string DatabaseName, string ClientsCollectionName, string FoodsCollectionName)
        {
            //collection.Services.Configure<DietDatabaseSettings>(
            //collection.Configuration.GetSection("DietDatabaseSettings"));

            collection.AddSingleton<IFoodRepository, FoodRepository>();

            collection.AddSingleton<IClientRepository, ClientRepository>();
            collection.AddSingleton<IDBManager, DBManager>();

            //https://stackoverflow.com/questions/64776364/dependency-injection-of-mongodb-connection-information-in-view-layer-of-mvc
         //   collection.Configure<IDietDatabaseSettings>(Configuration.GetSection("DietDatabaseSettings"));
            //collection.AddSingleton<IDietDatabaseSettings, DietDatabaseSettings>();
            collection.AddSingleton<IDietDatabaseSettings>(new DietDatabaseSettings(ConnectionString, DatabaseName, ClientsCollectionName, FoodsCollectionName));
            collection.AddSingleton<IDBManager>(new DBManager(ConnectionString));

            //collection.AddSingleton<IDietDatabaseSettings>(provider => provider.GetRequiredService<IOptions<DietDatabaseSettings>>().Value);
            //collection.AddControllersWithViews();
            //collection.AddControllers();
            //collection.AddScoped<MongoDB_Communicator>();
            return collection;
        }
    }
}
