using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compare2Files
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please type in two filenames.");
                return;
            }
            var filename0 = args[0];
            var filename1 = args[1];
            var file0 = new System.IO.FileStream(filename0, System.IO.FileMode.Open);
            var file1 = new System.IO.FileStream(filename1, System.IO.FileMode.Open);
            int index = 0;
            byte[] content0 = new byte[1];
            byte[] content1 = new byte[1];
            for (; index < file0.Length && index < file1.Length; index++)
            {
                file0.Read(content0, 0, 1);
                file1.Read(content1, 0, 1);
                if (content0[0] != content1[0])
                {
                    Console.WriteLine("Different...");
                }
            }

            Console.WriteLine("done");
        }
    }
}
