using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class   : Controller
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
            var formatSettings = _configuration.GetSection("PlatePlanDatabase").Get<DbSettings>();
        }
        [HttpGet("connection-string")]
        public string GetConnectionString()
        {
            string connectionString = _configuration.GetValue<string>("PlatePlanDatabase:ConnectionString");
            return connectionString;
        }
        [HttpGet("database-name")]
        public string GetDatabaseName()
        {
            string databaseName = _configuration.GetValue<string>("PlatePlanDatabase:DatabaseName");
            return databaseName;
        }
        [HttpGet("food-collection-name")]
        public string GetFoodCollectionName()
        {
            string foodCollectionName = _configuration.GetValue<string>("PlatePlanDatabase:FoodCollectionName");
            return foodCollectionName;
        }
        [HttpGet("clients-collection-name")]
        public string GetClientsCollectionName()
        {
            string clientsCollectionName = _configuration.GetValue<string>("PlatePlanDatabase:ClientsCollectionName");
            return clientsCollectionName;
        }
    }
}

