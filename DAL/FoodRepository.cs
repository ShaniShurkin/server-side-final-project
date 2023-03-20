namespace DAL
{
    //todo list:   try and catch to all functions
    public class FoodRepository : IFoodRepository
    {
        private IMongoCollection<Food> foodCollection;
        public FoodRepository(IDietDatabaseSettings settings, IDBManager dbConnection)
        {
            //to check if DI....
            var client = dbConnection.getDatabase();
            var database = client.GetDatabase(settings.DatabaseName);
            foodCollection = database.GetCollection<Food>(settings.FoodCollectionName);
        }

        public async Task<string> AddAsync(Food food)
        {
            await foodCollection.InsertOneAsync(food);
            //return id

            return "";

        }

        public async Task<bool> DeleteAsync(string code)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", code);
            await foodCollection.DeleteOneAsync(filter);
            //return task
            return true;

        }

        public async Task<List<Food>> GetAllAsync()
        {
            return await foodCollection.Find(_ => true).ToListAsync();
        }


        public async Task<Food> GetSingleAsync(string code)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", code);
            var food = await foodCollection.Find(filter).FirstOrDefaultAsync();
            return food;
        }

        public async Task<bool> UpdatAsync(Food food)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", food.Code);
            await foodCollection.ReplaceOneAsync(filter, food);                         
            return false;
        }
    }
}
