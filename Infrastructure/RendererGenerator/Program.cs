using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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
                DataStructure dataStructure = DataStructure.Parse(XElement.Load(args[0]));
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

                Process.Start("explorer", "/select," + args[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return;
            }
        }
    }
}
