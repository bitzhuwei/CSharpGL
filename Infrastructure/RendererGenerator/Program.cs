using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RendererGenerator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());

            Test();
        }

        private static void Test()
        {
            string targetName = "Demo";
            var dataStructure = new DataStructure(targetName);
            string nameInShader = "in_Position";
            string nameInModel = "position";
            Type type = typeof(vec3);
            var property = new VertexProperty(nameInShader, nameInModel, type);
            dataStructure.PropertyList.Add(property);
            // vertex shader.
            {
                ShaderBuilder vertexShaderBuilder = new VertexShaderBuilder();
                string vertexShaderCode = vertexShaderBuilder.Build(dataStructure);
                File.WriteAllText(vertexShaderBuilder.GetFilename(dataStructure), vertexShaderCode);
            }
            // fragment shader.
            {
                ShaderBuilder fragmentShaderBuilder = new FragmentShaderBuilder();
                string fragmentShaderCode = fragmentShaderBuilder.Build(dataStructure);
                File.WriteAllText(fragmentShaderBuilder.GetFilename(dataStructure), fragmentShaderCode);
            }
            // model.
            {
                var modelBuilder = new ModelBuilder();
                string modelFilename = modelBuilder.GetFilename(dataStructure);
                modelBuilder.Build(dataStructure, modelFilename);
            }
            // renderer.
            {
                var rendererBuilder = new RendererBuilder();
                string rendererFilename = rendererBuilder.GetFilename(dataStructure);
                rendererBuilder.Build(dataStructure, rendererFilename);
            }
        }
    }
}
