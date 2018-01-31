using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lighting.ShadowMapping
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
            Application.Run(new FormMain(GetPointLights(), "Lighting - Shadow Mapping - Point Lights - CSharpGL"));
            Application.Run(new FormMain(GetDirctionalLights(), "Lighting - Shadow Mapping - Directional Lights - CSharpGL"));
            Application.Run(new FormMain(GetSpotLights(), "Lighting - Shadow Mapping - Spot Lights - CSharpGL"));
        }


        private static List<LightBase> GetSpotLights()
        {
            var list = new List<LightBase>();
            double radian = 120.0 / 180.0 * Math.PI / 2.0;
            {
                var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(1, 0, 0);
                light.Specular = new vec3(1, 0, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(0, 1, 0);
                light.Specular = new vec3(0, 1, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(0, 0, 1);
                light.Specular = new vec3(0, 0, 1);
                list.Add(light);
            }

            return list;
        }

        private static List<LightBase> GetDirctionalLights()
        {
            var list = new List<LightBase>();
            {
                var light = new CSharpGL.DirectionalLight(new vec3(3, 3, 3));
                light.Diffuse = new vec3(1, 0, 0);
                light.Specular = new vec3(1, 0, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.DirectionalLight(new vec3(3, 3, 3));
                light.Diffuse = new vec3(0, 1, 0);
                light.Specular = new vec3(0, 1, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.DirectionalLight(new vec3(3, 3, 3));
                light.Diffuse = new vec3(0, 0, 1);
                light.Specular = new vec3(0, 0, 1);
                list.Add(light);
            }

            return list;
        }

        private static List<LightBase> GetPointLights()
        {
            var list = new List<LightBase>();
            {
                var light = new CSharpGL.PointLight(new vec3(3, 3, 3), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(1, 0, 0);
                light.Specular = new vec3(1, 0, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.PointLight(new vec3(3, 3, 3), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(0, 1, 0);
                light.Specular = new vec3(0, 1, 0);
                list.Add(light);
            }
            {
                var light = new CSharpGL.PointLight(new vec3(3, 3, 3), new Attenuation(2, 0, 0));
                light.Diffuse = new vec3(0, 0, 1);
                light.Specular = new vec3(0, 0, 1);
                list.Add(light);
            }

            return list;
        }

    }
}
