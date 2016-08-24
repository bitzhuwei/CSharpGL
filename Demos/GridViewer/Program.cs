using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace GridViewer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainWindow = new FormMain();
            //Rectangle rect = WindowSizeHelper.WindowSize(0.8f, 0.9f);
            //mainWindow.Size = rect.Size;
            mainWindow.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(mainWindow);
        }
    }
}
