using DAL.Models;
using System.Security.Cryptography;

namespace DAL
{
    //try and catch
    internal class ClientRepository : IClientRepository

    {
        private IMongoCollection<Client> clientsCollection;
        IDBManager dBManager;


        public ClientRepository(IDietDatabaseSettings settings, IDBManager dBManager)
        {
            this.dBManager = dBManager;
            var database = this.dBManager.getDatabase();
            clientsCollection = database.GetCollection<Client>(settings.ClientsCollectionName);
        }

        public async Task<string> AddAsync(Client client)
        {
            await clientsCollection.InsertOneAsync(client);
            //return id

            return "";
        }
        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Id", id);
            var result = await clientsCollection.FindOneAndDeleteAsync(filter);
            if (result != null)
                return true;
            return false;
        }
        public async Task<List<Client>> GetAllAsync()
        {
            var x = await clientsCollection.AsQueryable<Client>().ToListAsync();
            return x;
        }

        public async Task<Client> GetSingleAsync(string id)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Id", id);
            var client = await clientsCollection.Find(filter).FirstOrDefaultAsync();
            return client;
        }

        public async Task<bool> UpdatAsync(Client client)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Code", client.Code);
            var updated = await clientsCollection.ReplaceOneAsync(filter, client);
            if (updated != null)
                return true;
            return false;
        }
    }
}
