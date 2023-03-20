using DAL.Models;
using System.Security.Cryptography;

namespace DAL
{
    //try and catch
    internal class ClientRepository : IClientRepository

    {
        private IMongoCollection<Client> clientsCollection;
        
        public ClientRepository(IDietDatabaseSettings settings)
        {
           var client = new MongoClient(settings.ConnectionString);
           var database = client.GetDatabase(settings.DatabaseName);
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
            return await clientsCollection.Find(_ => true).ToListAsync();
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
