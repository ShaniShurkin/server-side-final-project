using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection collection)
        {
            

            collection.AddSingleton<IFoodRepository, FoodRepository>();
            collection.AddSingleton<IClientRepository, ClientRepository>();
            collection.AddSingleton<IDBManager, DBManager>();
            return collection;
        }
    }
}
