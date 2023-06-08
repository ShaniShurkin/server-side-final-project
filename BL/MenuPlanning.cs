using Amazon.Runtime.Internal;
using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using ThirdParty.Json.LitJson;

namespace BL
{
    public class MenuPlanning
    {
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
            double calorieNeeds;
            switch (activityLevel)
            {
                case ActivityLevel.sedentary:
                    calorieNeeds = bmr * 1.2;
                    break;
                case ActivityLevel.moderate:
                    calorieNeeds = bmr * 1.55;
                    break;
                case ActivityLevel.active:
                    calorieNeeds = bmr * 1.9;
                    break;
                default:
                    calorieNeeds = bmr * 1.55;
                    break;
            }
            return (int)calorieNeeds;
            // Print the result
        }

        public static async Task<string> CreateMenu(List<FoodDTO> foods, ClientDTO client)
        {
            double calorieNeeds = CalculateCalories(client);
            string json = JsonConvert.SerializeObject(foods);
            Dictionary<string, string> dict = new()
            {
                { "data", json },
                { "calorie needs", calorieNeeds.ToString() },
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
