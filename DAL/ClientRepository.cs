using DAL.Models;
using System.Security.Cryptography;

namespace DAL
{
    //try and catch
    internal class ClientRepository : IClientRepository

    {
        readonly IMongoCollection<Client> clientsCollection;
        readonly IDBManager dBManager;
        

        public ClientRepository(IDietDatabaseSettings settings, IDBManager dBManager)
        {
            this.dBManager = dBManager;
            var database = this.dBManager.getDatabase();
            clientsCollection = database.GetCollection<Client>(settings.ClientsCollectionName);
        }

        public async Task<int> AddAsync(Client client)
        {
            await clientsCollection.InsertOneAsync(client);
            return client.Code;
        }
        public async Task<bool> DeleteAsync(int code)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Code", code);
            var result = await clientsCollection.FindOneAndDeleteAsync(filter);
            if (result != null)
                return true;
            return false;
        }
        public async Task<List<Client>> GetAllAsync()
        {
            var clientsList = await clientsCollection.AsQueryable<Client>().ToListAsync();
            return clientsList;
        }

        public async Task<Client?> GetSingleAsync(string email)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("EmailAddress", email);
            var client = await clientsCollection.Find(filter).FirstOrDefaultAsync();
            return client;
        }
        public async Task<Client?> GetSingleAsync(int code)
        {
            FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Code", code);
            var client = await clientsCollection.Find(filter).FirstOrDefaultAsync();
            return client;
        }

        public async Task<bool> UpdatAsync(int code, Client client)
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
            Client newClient = await GetSingleAsync(code);
            client.ObjectId= newClient.ObjectId;
            var x = await clientsCollection.ReplaceOneAsync(x => x.Code == code, client);
            if(x!= null)
            {
                return true;
            }
            return false;
        }
    }
}
