using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace c06d00_TextureArray
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string filename = @"KleinBottle3.png";
            //ImageGenerator.Run(filename, 25, "0");
            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
