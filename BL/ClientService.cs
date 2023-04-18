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
        public Task<string> AddAsync(ClientDTO objectToAdd)
        {
            throw new NotImplementedException();
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

        public Task<bool> UpdateAsync(ClientDTO objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
