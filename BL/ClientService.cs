using DAL;
using MongoDB.Driver;

namespace BL
{
    internal class ClientService : IClientService
    {
        IClientRepository clientRepository;
        IMapper mapper;
        readonly List<Client> clients;   
        public static int CurrentCode { get; internal set; } = 0;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
            //try if there is Code
            this.clients = clientRepository.GetAllAsync().Result
               .OrderBy(f => f.Code).ToList();
            CurrentCode = clients.Last().Code;
        }
        public async Task<int> AddAsync(ClientDTO clientToAdd)
        {
            var existingClient = await Task.Run(()=> 
            clients.Find(client => client.EmailAddress==clientToAdd.EmailAddress));
                
            if (existingClient != null)
            {
                return existingClient.Code;
            }
            CurrentCode++;
            Client client = mapper.Map<Client>(clientToAdd);
            return await clientRepository.AddAsync(client);
        }

        public async Task<bool> DeleteAsync(int code)
        {
            return await clientRepository.DeleteAsync(code);
        }

        public async Task<List<ClientDTO>> GetAllAsync()
        {
            List<Client> clients = await clientRepository.GetAllAsync();
            return mapper.Map<List<ClientDTO>>(clients);
        }

        public async Task<ClientDTO?> GetSingleAsync(string email)
        {
            Client? client = await clientRepository.GetSingleAsync(email);
            return mapper.Map<ClientDTO?>(client);

        }
        public async Task<ClientDTO?> GetSingleAsync(int code)
        {
            Client? client = await clientRepository.GetSingleAsync(code);
            return mapper.Map<ClientDTO?>(client);

        }

        public async Task<bool> UpdateAsync(int code, ClientDTO objectToUpdate)
        {

            Client client = mapper.Map<Client>(objectToUpdate);
           
            //var oldClient = clientRepository.GetSingleAsync(objectToUpdate.Id);
            //var newClient = await mapper.Map(client, oldClient);
            return await clientRepository.UpdatAsync(code,client);
            //return true;
            //return await clientRepository.UpdatAsync(client);
        }

        
    }
}
