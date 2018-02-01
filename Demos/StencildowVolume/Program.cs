using CSharpGL;
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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string filename = string.Empty;
            //if (args == null || args.Length < 1) { filename = "dragon.obj_"; }
            //if (args == null || args.Length < 1) { filename = "buddha.obj_"; }
            if (args == null || args.Length < 1)
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                filename = System.IO.Path.Combine(folder, "bunny.obj_");
            }

            var parser = new ObjVNFParser(true);
            ObjVNFResult result = parser.Parse(filename);
            if (result.Error != null)
            {
                MessageBox.Show(result.Error.ToString());
            }
            else
            {
                IModelProvider provider = new AdjacentTriangleModelProvider(result.Mesh);
                var info = new ModelInfo(provider, AdjacentTriangleModel.strPosition, AdjacentTriangleModel.strNormal, provider.Size);
                //Application.Run(new FormAdjacentTriangles(info));
                //Application.Run(new Form0SilhouetteDetection(info));
                //Application.Run(new Form1ExtrudeVolume(info));
                Application.Run(new Form2ShadowVolume(GetPointLights()));
            }
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

    public class AdjacentTriangleModelProvider : IModelProvider
    {
        private ObjVNFMesh mesh;

        public AdjacentTriangleModelProvider(ObjVNFMesh mesh)
        {
            this.mesh = mesh;
        }
        #region IModelProvider 成员

        public IBufferSource Model
        {
            get { return new AdjacentTriangleModel(mesh); }
        }

        public vec3 Size
        {
            get { return this.mesh.Size; }
        }

        #endregion
    }
    public interface IModelProvider
    {
        IBufferSource Model { get; }

        vec3 Size { get; }
    }

    public class ModelInfo
    {
        public readonly IModelProvider modelProvider;
        public readonly string position;
        public readonly string normal;
        public readonly vec3 size;

        public ModelInfo(IModelProvider modelProvider, string position, string normal, vec3 size)
        {
            this.modelProvider = modelProvider;
            this.position = position;
            this.normal = normal;
            this.size = size;
        }
    }
}
