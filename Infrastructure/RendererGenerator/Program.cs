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
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please specify a valid xml file.");
                Console.ReadKey();
                return;
            }

            try
            {
                //DataStructure dataStructure = DataStructure.Parse(XElement.Load(args[0]));
                var dataStructure = new DataStructure();
                dataStructure.TargetName = "Demo";
                string nameInShader = "in_Position";
                string nameInModel = "position";
                Type type = typeof(vec3);
                var property = new VertexProperty(nameInShader, nameInModel, type);
                dataStructure.PropertyList.Add(property);
                dataStructure.ToXElement().Save("Demo.xml");
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
