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

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClientDTO>> GetAllAsync()
        {
            List<Client> clients = await clientRepository.GetAllAsync();
            return mapper.Map<List<ClientDTO>>(clients);
        }

        public Task<ClientDTO> GetSingleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ClientDTO objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
