namespace BL
{
    internal class ClientService : IClientService
    {
        IClientRepository clientRepository;
        IMapper mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }
        public async Task<string> AddAsync(ClientDTO objectToAdd)
        {
            Client client = mapper.Map<Client>(objectToAdd);
            return await clientRepository.AddAsync(client);
        }

        public async Task<bool> DeleteAsync(string code)
        {
            return await clientRepository.DeleteAsync(code);
        }

        public async Task<List<ClientDTO>> GetAllAsync()
        {
            List<Client> clients = await clientRepository.GetAllAsync();
            return mapper.Map<List<ClientDTO>>(clients);
        }

        public async Task<ClientDTO> GetSingleAsync(string code)
        {
            Client client = await clientRepository.GetSingleAsync(code);
            return mapper.Map<ClientDTO>(client);

        }

        public async Task<bool> UpdateAsync(string id, ClientDTO objectToUpdate)
        {

            Client client = mapper.Map<Client>(objectToUpdate);
           
            //var oldClient = clientRepository.GetSingleAsync(objectToUpdate.Id);
            //var newClient = await mapper.Map(client, oldClient);
            return await clientRepository.UpdatAsync(id,client);
            //return true;
            //return await clientRepository.UpdatAsync(client);
        }
    }
}
