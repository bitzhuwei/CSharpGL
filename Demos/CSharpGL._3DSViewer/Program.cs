using CSharpGL.FileParser._3DSParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL._3DSViewer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Test3DSFiles();
            return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3DSViewer());
        }

        private static void Test3DSFiles()
        {
            var filename = "Books.3DS";
            ThreeDSParser parser = new ThreeDSParser();
            parser.Parse(filename);
        }
    }
}
