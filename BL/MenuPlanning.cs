using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MenuPlanning
    {

        public string option1()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = "C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python37\\python.exe";
            var script = "..\\..\\..\\simplex.py";
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


    }
}
