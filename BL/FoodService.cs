using DAL.Interfaces;

namespace BL
{
    internal class FoodService : IFoodService
    {
        IFoodRepository foodRepository;
        IMapper mapper;
        public FoodService(IFoodRepository foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
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
        public async Task<List<FoodDTO>> GetAllAsync()
        {
            List<Food> foods = await foodRepository.GetAllAsync();
            return mapper.Map<List<FoodDTO>>(foods);
        }

        public async Task<FoodDTO> GetSingleAsync(int code)
        {
            Food food = await foodRepository.GetSingleAsync(code);
            return mapper.Map<FoodDTO>(food);
        }

        public Task<bool> UpdateAsync(string id, FoodDTO objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
