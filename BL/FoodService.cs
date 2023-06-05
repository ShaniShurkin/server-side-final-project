using DAL.Interfaces;

namespace BL
{
    internal class FoodService : IFoodService
    {
        IFoodRepository foodRepository;
        IMapper mapper;
        public static int CurrentCode { get; internal set; }
        public FoodService(IFoodRepository foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
            var sortedFoodList = foodRepository.GetAllAsync().Result
                .OrderBy(f => f.Code).ToList();
            CurrentCode = sortedFoodList.Last().Code;
        }
        public Task<int> AddAsync(FoodDTO objectToAdd)
        {
            CurrentCode++;
            Food food = mapper.Map<Food>(objectToAdd);
            return foodRepository.AddAsync(food);
        }

        public Task<bool> DeleteAsync(int code)
        {
           return foodRepository.DeleteAsync(code);
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

        public Task<bool> UpdateAsync(int code, FoodDTO foodToUpdate)
        {
            Food food = mapper.Map<Food>(foodToUpdate);
            return foodRepository.UpdatAsync(code, food);
        }
    }
}
