using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DumpUnicode2File();

            Console.WriteLine("Done");
            Console.ReadKey(true);
        }

        private static void DumpUnicode2File()
        {
            using (StreamWriter sw = new StreamWriter("unicode.txt", false, Encoding.Unicode))
            {
                int maxValue = (int)char.MaxValue;
                char c = char.MinValue;
                for (int i = 0; i <= maxValue; i++, c++)
                {
                    sw.Write(i);
                    sw.Write("[");
                    sw.Write(c);
                    sw.Write("]");
                    if (i % 8 == 7) { sw.WriteLine(); }
                }
            }
        }
    }
}
