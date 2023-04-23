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
            return client.Id;
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
            //FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Id", client.Id);
            //var updated = await clientsCollection.ReplaceOneAsync(filter, client);
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, Book>()
            //    .ForAllMembers(opts => opts.Condition((src, dest, member) => member != null)));
            //var mapper = config.CreateMapper();
            //Task<Client> oldClient = GetSingleAsync(client.Id);
            //var margedClient = mapper.Map(client, oldClient);
            ////https://stackoverflow.com/questions/14853362/mongodb-update-only-specific-fields
            //if (updated != null)
            //    return true;

            //UpdateDefinition<Client> update = Builders<Client>.Update(client);
            //await clientsCollection.UpdateOneAsync(filter, client);
            //return;
            Client newClient = await GetSingleAsync(client.Id);
            client.ObjectId= newClient.ObjectId;
            var x = await clientsCollection.ReplaceOneAsync(x => x.Id == client.Id, client);
            if(x!= null)
            {
                return true;
            }
            return false;
        }
    }
}
