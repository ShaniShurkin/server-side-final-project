using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class MenuRepository : IMenuRepository
    {
        private readonly IMongoCollection<Client> clientsCollection;
        readonly IDBManager dBManager;


        public MenuRepository(IDietDatabaseSettings settings, IDBManager dBManager)
        {
            this.dBManager = dBManager;
            var database = this.dBManager.getDatabase();
            this.clientsCollection = database.GetCollection<Client>(settings.ClientsCollectionName);
        }
        public async Task<bool> UpdateMenu(int code, string menu)
        {
            var filter = Builders<Client>.Filter.Eq("Code", code);
            var update = Builders<Client>.Update.Set("menu", menu);
            var result = await clientsCollection.UpdateOneAsync(filter, update);
            return result.MatchedCount != 0;
        }
    }
}
