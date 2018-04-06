using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace c06d01_2DTextureArray
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    string filename = string.Format("texture2D ({0}).png", i);
            //    ImageGenerator.Run(filename, i.ToString());
            //}
            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
