namespace DAL
{
    internal class ClientRepository : IClientRepository

    {
        private IMongoCollection<Client> clientsCollection;
        
        public ClientRepository(IDietDatabaseSettings settings)
        {
           var client = new MongoClient(settings.ConnectionString);
           var database = client.GetDatabase(settings.DatabaseName);
           clientsCollection = database.GetCollection<Client>(settings.ClientsCollectionName);
         }
	 
        public IMongoCollection<Food> FileService(IDietDatabaseSettings settings)
        {
           
        }
        
        public async Task<string> AddAsync(Client objectToAdd)
        {
           await 
        }
        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task<List<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetSingleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatAsync(Client objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
