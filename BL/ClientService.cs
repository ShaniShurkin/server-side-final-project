using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class ClientService : IClientService
    {
        public Task<string> AddAsync(ClientDTO objectToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
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
