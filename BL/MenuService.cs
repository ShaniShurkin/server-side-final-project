using Newtonsoft.Json;

namespace BL
{
    internal class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {

            this.menuRepository = menuRepository;

        }
        public async Task<bool> UpdateMenu(int code, string menu)
        {
            return await menuRepository.UpdateMenu(code, menu);
        }
        public static int CalculateCalories(ClientDTO client)
        {
            // Calculate BMR based on gender
            double bmr;
            if (client.Gender == Gender.female)
            {
                bmr = 88.36 + (13.4 * client.Weight) + (4.8 * client.Height) - (5.7 * client.Age);
            }
            else
            {
                bmr = 447.6 + (9.2 * client.Weight) + (3.1 * client.Height) - (4.3 * client.Age);
            }
            ActivityLevel activityLevel = client.ActivityLevel;
            var calorieNeeds = activityLevel switch
            {
                ActivityLevel.sedentary => bmr * 1.2,
                ActivityLevel.moderate => bmr * 1.55,
                ActivityLevel.active => bmr * 1.9,
                _ => bmr * 1.55,
            };
            return (int)calorieNeeds;

        }

        public async Task<string> CreateMenu(List<FoodDTO> foods, ClientDTO client)
        {
            double calorieNeeds = CalculateCalories(client);
            string json = JsonConvert.SerializeObject(foods);
            //Dictionary<int, double> caloriesPerMeal;
            //Dictionary<int, List<int>> categoriesPerMeal;
            //if(client.Meals != null)
            //{
            //caloriesPerMeal = client.Meals.ToDictionary(meal => meal.Code, meal => meal.Calories);
            //categoriesPerMeal = client.Meals.ToDictionary(meal => meal.Code, meal => meal.Categories);
            //}

            Dictionary<string, double> mealsCalories = new()
            {
                { "Breakfast", 0.15 },
                { "Snack1", 0.1 },
                { "Lunch", 0.35 },
                { "Snack2", 0.1 },
                { "Dinner", 0.3 }
            };
            Dictionary<string, int[]> mealCategories = new()
            {
                { "Breakfast", new int[] { 1, 2, 3 } },
                { "Snack1", new int[] { 4, 5 } },
                { "Lunch", new int[] { 6, 1 } },
                { "Snack2", new int[] { 7, 2, 8 } },
                { "Dinner", new int[] { 9, 1, 4, 5 } }
            };
            Dictionary<string, string> dict = new()
            {
                {"data", json },
                {"calorieConsumption", calorieNeeds.ToString() },
                //{"mealCategories", JsonConvert.SerializeObject(categoriesPerMeal) },
                //{"mealsCalories",  JsonConvert.SerializeObject(caloriesPerMeal) },
                { "mealCategories", JsonConvert.SerializeObject(mealCategories) },
                { "mealsCalories", JsonConvert.SerializeObject(mealsCalories) },
                { "weight", client.Weight.ToString() }
            };
            string apiUrl = "http://localhost:5000/process_data";
            HttpClient httpClient = new();
            string jsonData = JsonConvert.SerializeObject(dict);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            return result;
        }

    }
}
