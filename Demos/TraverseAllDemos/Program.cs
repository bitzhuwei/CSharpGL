using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TraverseAllDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string self = typeof(Program).Assembly.Location;
                string folder = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                var dirInfo = new System.IO.DirectoryInfo(folder);
                var demoRootDir = dirInfo.Parent.Parent.Parent;

                string[] exes = System.IO.Directory.GetFiles(demoRootDir.FullName, "*.exe", System.IO.SearchOption.AllDirectories);
                foreach (var item in exes)
                {
                    if (item.ToLower().EndsWith(".vshost.exe")) { continue; }
                    if (item.ToLower().Contains(@"\obj\")) { continue; }
                    if (item.ToLower().Contains(@"\release\")) { continue; }
                    if (item == self) { continue; }

                    Process proc = Process.Start(item);
                    proc.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
