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
                var demoRootDir = dirInfo.Parent.Parent.Parent; // Demos\...

                string[] exes = (from item in System.IO.Directory.GetFiles(demoRootDir.FullName, "*.exe", System.IO.SearchOption.AllDirectories)
                                 orderby item
                                 select item).ToArray();
                foreach (var item in exes)
                {
                    if (item.ToLower().EndsWith(".vshost.exe")) { continue; }
                    if (item.ToLower().Contains(@"\obj\")) { continue; }
                    if (item.ToLower().Contains(@"\release\")) { continue; }
                    if (item == self) { continue; }

                    Console.WriteLine("Opening {0} ...", item);
                    Process proc = Process.Start(item);
                    proc.WaitForExit();
                }

                Console.WriteLine("All done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // memo: rename "*State.cs" to "*Switch.cs".
        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        string self = typeof(Program).Assembly.Location;
        //        string folder = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        //        var dirInfo = new System.IO.DirectoryInfo(folder);
        //        var demoRootDir = System.IO.Path.Combine(dirInfo.Parent.Parent.Parent.Parent.FullName, "CSharpGL"); // CSharpGL\...

        //        string[] exes = (from item in System.IO.Directory.GetFiles(demoRootDir, "*State.cs", System.IO.SearchOption.AllDirectories)
        //                         orderby item
        //                         select item).ToArray();
        //        foreach (var item in exes)
        //        {
        //            Console.WriteLine("Opening {0} ...", item);
        //            var fileInfo = new System.IO.FileInfo(item);
        //            string newName = item.Substring(0, item.Length - "State.cs".Length) + "Switch.cs";
        //            fileInfo.MoveTo(newName);
        //        }

        //        Console.WriteLine("All done!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //}
    }
}
