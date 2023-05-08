using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class MenuPlanning
    {

        static void option1()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = "C:\\Program Files\\Python311\\python.exe";
            var script = "C:\\script2.py";
            var start = "2019-1-1";
            var end = "2019-1-22";
            psi.Arguments = $"\"{script}\" \"{start}\" \"{end}\" \"5\"";
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

        }


    }
}
