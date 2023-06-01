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
      
        public async Task<string> CreateMenu(List<FoodDTO> foods)
        {
            string json = JsonConvert.SerializeObject(foods);
            string apiUrl = "http://localhost:5000/process_data";
            HttpClient client = new HttpClient();
            string inputData = JsonConvert.SerializeObject(json);
            StringContent content = new StringContent(inputData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            return result;
        }


    }
}
