﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StencilShadowVolume
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
            Application.Run(new Form0SilhouetteDetection());
            Application.Run(new Form1ExtrudeVolume());
            Application.Run(new Form2ShadowVolume());
        }
    }
}