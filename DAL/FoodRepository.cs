namespace DAL
{
    //todo list:   try and catch to all functions
    public class FoodRepository : IFoodRepository
    {
        private IMongoCollection<Food> foodCollection;
        IDBManager dBManager;
        public FoodRepository(IDietDatabaseSettings settings, IDBManager dBManager)
        {
            //to check if DI....
            this.dBManager = dBManager;
            var database = this.dBManager.getDatabase();
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
           var x= await foodCollection.Find(_ => true).ToListAsync();
            return x;
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
