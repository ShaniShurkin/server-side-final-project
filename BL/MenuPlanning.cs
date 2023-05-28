using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace BL
{
    public class MenuPlanning
    {
        public string option1()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = "C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python37\\python.exe";
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\..\simplex.py");
            string sFilePath = Path.GetFullPath(sFile);
            Console.WriteLine(sFilePath);
            var start = "2019-1-1";
            var end = "2019-1-22";
            psi.Arguments = $"\"{sFilePath}\" \"{start}\" \"{end}\" \"5\"";
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
            using (var client = new HttpClient())
            {
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                /*var response = await client.PostAsync("http://localhost:5000/api/process_data", content);*/
                
                var response2 = await client.GetAsync("http://localhost:5000/api/process_data",);
                string data = await response2.Content.ReadAsStringAsync();
                Console.WriteLine(data);
                return data;
            }
        }

    }
}
