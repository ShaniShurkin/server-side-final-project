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
        public async Task<bool> DeleteAsync(string code)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Code", code);
            await clientsCollection.DeleteOneAsync(filter);
            //return task
            return true;
        }
        public async Task<List<Client>> GetAllAsync()
        {
            var x = await clientsCollection.AsQueryable<Client>().ToListAsync();
            return x;
        }

        public async Task<Client> GetSingleAsync(string code)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Code", code);
            var client = await clientsCollection.Find(filter).FirstOrDefaultAsync();
            return client;
        }

        public async Task<bool> UpdatAsync(Client client)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Code", client.Code);
            await clientsCollection.ReplaceOneAsync(filter, client);
            return false;
        }
    }
}
