using BL.DTO;
using DAL;
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
        public FoodService(FoodRepository foodRepo)
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
        //https://stackoverflow.com/questions/68221617/struggling-with-returning-a-task-using-mongodriver-and-catching-the-error
        public Task<List<Food>> GetAllAsync()
        {
            return foodRepo.GetAllAsync();
            //List<Food> list;
            //try
            //{
            //    list = await foodRepo.Find(book => true).ToListAsync();
            //    return list;
            //}
            //catch (Exception e)
            //{
            //    var exceptionTask = new Task(() => { throw e; });
            //    exceptionTask.RunSynchronously();
            //    return exceptionTask;
            //}
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
