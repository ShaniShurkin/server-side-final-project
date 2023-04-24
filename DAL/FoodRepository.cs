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
        }

        public async Task<string> AddAsync(Food food)
        {
            await foodsCollection.InsertOneAsync(food);
            //return id

            return food.Id;

        }

        public async Task<bool> DeleteAsync(string code)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", code);
            await foodsCollection.DeleteOneAsync(filter);
            //return task
            return true;

        }

        public async Task<List<Food>> GetAllAsync()
        {
           var x= await foodsCollection.Find(_ => true).ToListAsync();
            return x;
        }


        public async Task<Food> GetSingleAsync(string code)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", code);
            var food = await foodsCollection.Find(filter).FirstOrDefaultAsync();
            return food;
        }

        public async Task<bool> UpdatAsync(string id, Food food)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", food.Code);
            await foodsCollection.ReplaceOneAsync(filter, food);                         
            return false;
        }
    }
}
