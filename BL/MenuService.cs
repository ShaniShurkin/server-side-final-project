using Newtonsoft.Json;

namespace BL
{
    internal class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;
        private readonly IClientService clientService;

        public MenuService(IMenuRepository menuRepository, IClientService clientService)
        {

            this.menuRepository = menuRepository;
            this.clientService = clientService;

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

        public async Task<string> CreateMenu(List<FoodDTO> foods, int code)
        {
            ClientDTO? client = await clientService.GetSingleAsync(code);
            if (client == null)
            {
                client = await clientService.GetDefaultClientAsync();
            }
            double calorieNeeds = CalculateCalories(client);
            string json = JsonConvert.SerializeObject(foods);
            //Dictionary<int, double> caloriesPerMeal;
            //Dictionary<int, List<int>> categoriesPerMeal;
            //if(client.Meals != null)
            //{
            //caloriesPerMeal = client.Meals.ToDictionary(meal => meal.Code, meal => meal.Calories);
            //categoriesPerMeal = client.Meals.ToDictionary(meal => meal.Code, meal => meal.Categories);
            //}

            //Dictionary<string, double> mealsCalories = new()
            //{
            //    { "Breakfast", 0.15 },
            //    { "Snack1", 0.1 },
            //    { "Lunch", 0.35 },
            //    { "Snack2", 0.1 },
            //    { "Dinner", 0.3 }
            //};
            //Dictionary<string, int[]> mealCategories = new()
            //{
            //    { "Breakfast", new int[] { 1, 2, 3 } },
            //    { "Snack1", new int[] { 4, 5 } },
            //    { "Lunch", new int[] { 6, 1 } },
            //    { "Snack2", new int[] { 7, 2, 8 } },
            //    { "Dinner", new int[] { 9, 1, 4, 5 } }
            //};
            List<MealDTO> meals;
            if (client.Meals == null || !client.Meals.Any())
            {
                ClientDTO defaultClient = await clientService.GetDefaultClientAsync();
                meals = defaultClient.Meals;

            }
            else
            {
                meals = client.Meals;
            }         
            Dictionary<string, string> dict = new()
            {
                {"data", json },
                {"calorieConsumption", calorieNeeds.ToString() },
                {"meals", JsonConvert.SerializeObject(meals ) },
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
