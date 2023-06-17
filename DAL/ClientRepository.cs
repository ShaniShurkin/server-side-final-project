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
            try
            {
                this.dBManager = dBManager;
                var database = this.dBManager.getDatabase();
                clientsCollection = database.GetCollection<Client>(settings.ClientsCollectionName);
            }
            catch (MongoConnectionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(Client client)
        {
            try
            {
                await clientsCollection.InsertOneAsync(client);
                return client.Code;
            }
            catch (MongoWriteException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteAsync(int code)
        {
            try
            {
                FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Code", code);
                var result = await clientsCollection.FindOneAndDeleteAsync(filter);
                if (result != null)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Client>> GetAllAsync()
        {
            try
            {
                var clientsList = await clientsCollection.AsQueryable<Client>().ToListAsync();
                return clientsList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Client?> GetSingleAsync(string email)
        {
            try
            {
                FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("EmailAddress", email);
                var client = await clientsCollection.Find(filter).FirstOrDefaultAsync();
                return client;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Client?> GetSingleAsync(int code)
        {
            try
            {
                FilterDefinition<Client> filter = Builders<Client>.Filter.Eq("Code", code);
                var client = await clientsCollection.Find(filter).FirstOrDefaultAsync();
                return client;
            }
            catch(Exception ex) { throw ex; }
        }

        public async Task<bool> UpdatAsync(int code, Client client)
        {
            try
            {
                Client newClient = await GetSingleAsync(code);
                client.ObjectId = newClient.ObjectId;
                var x = await clientsCollection.ReplaceOneAsync(x => x.Code == code, client);
                if (x != null)
                {
                    return true;
                }
                return false;
            }
            catch (MongoWriteException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
