using CSharpGL.OBJParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.ObjViewer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Test();
            //return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormCylinderElement());
            Application.Run(new FormObjViewer());
        }

        static void Test()
        {
            var model = ObjFile.Load("teapot_0.obj");
        }
    }
}
