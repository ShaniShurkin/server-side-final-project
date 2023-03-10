﻿using Microsoft.Extensions.DependencyInjection;
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
           

// Add services to the container.
            collection.Services.Configure<DietDatabaseSettings>(
            collection.Configuration.GetSection("DietDatabaseSettings"));

            collection.AddSingleton<IFoodRepository, FoodRepository>();
            collection.AddSingleton<IClientRepository, ClientRepository>();
            collection.AddSingleton<IDBManager, DBManager>();
            return collection;
        }
    }
}
