using BL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class FoodService : IFoodService
    {
        IFoodRepository foodRepo;
        public DriverService(IFoodRepository foodRepo)
        {
            this.foodRepo = foodRepo;
        }
        public Task<string> AddAsync(FoodDTO objectToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Food>> GetAllAsync()
        {
            List<Food> food = await driverRepo.GetAllAsync();
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
