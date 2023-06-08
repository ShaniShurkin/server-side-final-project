namespace DAL
{
    public class FoodRepository : IFoodRepository
    {
        readonly IMongoCollection<Food> foodsCollection;
        readonly IDBManager dBManager;
        public FoodRepository(IDietDatabaseSettings settings, IDBManager dBManager)
        {
            //to check if DI....
            this.dBManager = dBManager;
            try
            {
                var database = this.dBManager.getDatabase();
                foodsCollection = database.GetCollection<Food>(settings.FoodCollectionName);
                //var cat = database.GetCollection<Category>(settings.CategoriesCollectionName);
                //List<Category> catList = cat.AsQueryable<Category>().ToListAsync().Result;

            }
            catch (Exception)
            {
                ////////
            }


          }

        public async Task<int> AddAsync(Food food)
        {
            try
            {
                await foodsCollection.InsertOneAsync(food);
                return food.Code;
            }
            catch (Exception) {
                return 0; 
                ////
            }
            
        }

        public async Task<bool> DeleteAsync(int code)
        {
            FilterDefinition<Food> filter = Builders<Food>
                .Filter.Eq("Code", code);
            try
            {
                var result = await foodsCollection
                    .FindOneAndDeleteAsync(filter);
                if (result != null)
                    return true;
                return false;
            }
            catch {
                return false;
            }
        }

        public async Task<List<Food>> GetAllAsync()
        {
            try
            {
                var foodsList = await foodsCollection
                    .AsQueryable<Food>().ToListAsync();
                return foodsList;
            }
            catch
            {
                return null;
                ///
            }
        }


        public async Task<Food?> GetSingleAsync(int code)
        {
            FilterDefinition<Food> filter = Builders<Food>
                .Filter.Eq("Code", code);

            return await foodsCollection.Find(filter)
                .FirstOrDefaultAsync();
                 
         }

        public async Task<bool> UpdatAsync(int code, Food food)
        {
            FilterDefinition<Food> filter = Builders<Food>
                .Filter.Eq("Code", food.Code);
            try
            {
                var updatedFood = await foodsCollection
                    .ReplaceOneAsync(filter, food);
                if (updatedFood != null) return true;
                return false;
            }
            catch
            {
                return false; 
                ///
            }
        }
    }
}
