using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prepare to delete all *.log files...");
            string[] paths = System.IO.Directory.GetFiles(".", "*.log", System.IO.SearchOption.AllDirectories);
            foreach (var item in paths)
            {
                Console.WriteLine("Deleting {0}", item);
                System.IO.File.Delete(item);
            }

            Console.WriteLine("All done!");
            Console.ReadKey();  
        }
    }
}
