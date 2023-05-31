using Newtonsoft.Json;
using Python.Runtime;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace BL
{
    public class MenuPlanning
    {
        public string option1List(List<FoodDTO> foods)
        {
            string json = JsonConvert.SerializeObject(foods);
            var psi = new ProcessStartInfo();
            psi.FileName = "C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python37\\python.exe";
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\..\simplex.py");
            string sFilePath = Path.GetFullPath(sFile);
            Console.WriteLine(sFilePath);
            psi.Arguments = $"\"{sFilePath}\" ";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";
            var result = "";
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                result = process.StandardOutput.ReadToEnd();
            }
            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(result);
            return result;

        }
        public async Task<string> Option3Async(List<FoodDTO> foods)
        {
            string json = JsonConvert.SerializeObject(foods);
            return await PostData(json);
            // return await GetData();

            //
            //using (var client = new HttpClient())
            //{
            //    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //    /*var response = await client.PostAsync("http://localhost:5000/api/process_data", content);*/

            //    var response2 = await client.GetAsync("http://localhost:5000/api/process_data",);
            //    string data = await response2.Content.ReadAsStringAsync();
            //    Console.WriteLine(data);
            //    return data;
            //}
        }
        static async Task<string> GetData()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5000/api/data"; // Replace with the actual server URL
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    return jsonResponse;
                }
                else
                {
                    Console.WriteLine("GET request failed with status code: " + response.StatusCode);
                }
                return "";
            }
        }
        static async Task<string> PostData(string json)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5000/api/data"; // Replace with the actual server URL

                // Create a sample request data
                //var requestData = new
                //{
                //    name = "John Doe",
                //    age = 30,
                //    email = "johndoe@example.com"
                //};

                // Set request headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convert the request data to JSON
                //var jsonRequest = JsonConvert.SerializeObject(requestData);

                // Create the HTTP content with JSON
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    Console.WriteLine("POST request failed with status code: " + response.StatusCode);
                }
            }
            return "";
        }

        public string UsePythonnet()
        {
            PythonEngine.Initialize();
            PythonEngine.BeginAllowThreads();
            using var _ = Py.GIL();

            dynamic np = Py.Import("numpy");
            return (np.cos(np.pi * 2));
        }


    }
}
