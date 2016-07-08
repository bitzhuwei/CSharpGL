using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string filename = string.Format("CSharpGL{0:yyyy-MM-dd_HH-mm-ss.ff}.log", DateTime.Now);
            Debug.Listeners.Add(new TextWriterTraceListener(filename));
            Debug.AutoFlush = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            {
                ErrorCode error = (ErrorCode)OpenGL.GetError();
                if (error != ErrorCode.NoError)
                {
                    Debug.WriteLine(string.Format("OpenGL error: {0}", error));
                }
            }
            Debug.Close();
            Debug.Listeners.Clear();
        }
    }
}
