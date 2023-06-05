namespace DAL
{
    //todo list:   try and catch to all functions
    public class FoodRepository : IFoodRepository
    {
        private IMongoCollection<Food> foodsCollection;
        IDBManager dBManager;
        public FoodRepository(IDietDatabaseSettings settings, IDBManager dBManager)
        {
            //to check if DI....
            this.dBManager = dBManager;
            var database = this.dBManager.getDatabase();
            foodsCollection = database.GetCollection<Food>(settings.FoodCollectionName);
            var cat = database.GetCollection<Category>(settings.CategoriesCollectionName);
            List<Category> catList = cat.AsQueryable<Category>().ToListAsync().Result;
            foreach (var item in catList)
            {
                Console.WriteLine( item.HebrewName);

            }
          }

        public async Task<int> AddAsync(Food food)
        {
            await foodsCollection.InsertOneAsync(food);
             return food.Code;

        }

        public async Task<bool> DeleteAsync(int code)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", code);
            await foodsCollection.DeleteOneAsync(filter);
            //return task
            return true;

        }

        public async Task<List<Food>> GetAllAsync()
        {
            var x = await foodsCollection.AsQueryable<Food>().ToListAsync();
            return x;
        }


        public async Task<Food> GetSingleAsync(int code)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", code);
            var food = await foodsCollection.Find(filter).FirstOrDefaultAsync();
            return food;
 
        }

        public async Task<bool> UpdatAsync(int code, Food food)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", food.Code);
            await foodsCollection.ReplaceOneAsync(filter, food);                         
            return false;
        }
    }
}
