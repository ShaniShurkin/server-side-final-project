using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class ClientRepository : IClientRepository
    {
        public Task<string> AddAsync(Client objectToAdd)
        {
            throw new NotImplementedException();
        }
        //public async Task<List<Food>> GetAllAsync()
        //{
        //    await _foodsCollection.Find(_ => true).ToListAsync();
        //}
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
