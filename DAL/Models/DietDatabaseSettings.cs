using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DietDatabaseSettings : IDietDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ClientsCollectionName { get; set; } = null!;
        public string FoodCollectionName { get; set; } = null!;
    }
}
