using System;

using System.Windows.Forms;

namespace GridViewer
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
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