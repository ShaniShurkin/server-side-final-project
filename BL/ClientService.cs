namespace BL
{
    internal class ClientService : IClientService
    {
        IClientRepository clientRepository;
        IMapper mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper )
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }
        public async Task<string> AddAsync(ClientDTO objectToAdd)
        {
            Client client = mapper.Map<Client>(objectToAdd);
            return await clientRepository.AddAsync(client);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await clientRepository.DeleteAsync(id);
        }

        public async Task<List<ClientDTO>> GetAllAsync()
        {
            List<Client> clients = await clientRepository.GetAllAsync();
            return mapper.Map<List<ClientDTO>>(clients);
        }

        public async Task<ClientDTO> GetSingleAsync(string id)
        {
            Client client = await clientRepository.GetSingleAsync(id);
            return mapper.Map<ClientDTO>(client);

        }

        public async Task<bool> UpdateAsync(ClientDTO objectToUpdate)
        {

            Client client = mapper.Map<Client>(objectToUpdate);
           
            //var oldClient = clientRepository.GetSingleAsync(objectToUpdate.Id);
            //var newClient = await mapper.Map(client, oldClient);
            return await clientRepository.UpdatAsync(client);
            //return true;
            //return await clientRepository.UpdatAsync(client);
        }
    }
}
