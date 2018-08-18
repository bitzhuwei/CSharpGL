using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace c07d02_ShadowVolume.StencilTest
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
            Application.Run(new FormMain(GetPointLights(), "Lighting - Shadow Volume - Point Lights - CSharpGL"));
        }

        private static List<LightBase> GetPointLights()
        {
            var list = new List<LightBase>();
            {
                //var light = new CSharpGL.PointLight(new vec3(3, 3, 3), new Attenuation(2, 0, 0));
                var light = new CSharpGL.DirectionalLight(new vec3(0, 0, 1));
                light.Diffuse = new vec3(1, 1, 1);
                light.Specular = new vec3(1, 1, 1);
                list.Add(light);
            }

            return list;
        }

    }
}
