using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection collection)
        {
            collection.AddSingleton<IClientService, ClientService>();
            collection.AddSingleton<IFoodService, FoodService>();
            collection.AddRepositories();
            return collection;
        }
    }
}
