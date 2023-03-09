using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodRepository : IFoodRepository
    {

        public Task<string> AddAsync(Food objectToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Food>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Food> GetSingleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatAsync(Food objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
