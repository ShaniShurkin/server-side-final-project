using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class FoodService : IFoodService
    {
        public Task<string> AddAsync(FoodDTO objectToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FoodDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FoodDTO> GetSingleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(FoodDTO objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
