using CSharpShaderLanguage;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpGL.CSSL2GLSL
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            var originalOutput = Console.Out;
            using (TextWriter writer = File.CreateText(string.Format("CSSL2GLSLDump{0}.log", time)))
            {
                Console.SetOut(writer);

                try
                {
                    string directoryName = string.Empty;
                    if (args.Length > 0)
                    {
                        directoryName = args[0];
                    }
                    else
                    {
                        directoryName = Environment.CurrentDirectory;
                    }
                    string[] files = System.IO.Directory.GetFiles(directoryName, "*.cs",
                        System.IO.SearchOption.AllDirectories);
                    foreach (var fullname in files)
                    {
                        Console.WriteLine("--> Translating {0}", fullname);
                        TranslateCSharpShaderLanguage2GLSL(fullname);
                        Console.WriteLine();
                    }

                    Console.WriteLine("Translation all done!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            Console.SetOut(originalOutput);
            Console.WriteLine("All done!");
        }

        private static void TranslateCSharpShaderLanguage2GLSL(string fullname)
        {
            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();

            CompilerParameters objCompilerParameters = new CompilerParameters();
            objCompilerParameters.ReferencedAssemblies.Add("System.dll");
            objCompilerParameters.ReferencedAssemblies.Add("CSharpShaderLanguage.dll");
            objCompilerParameters.GenerateExecutable = false;
            objCompilerParameters.GenerateInMemory = true;
            //objCompilerParameters.IncludeDebugInformation = true;
            //objCompilerParameters.OutputAssembly = "tmptmptmp.dll";
            CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromFile(
                objCompilerParameters, fullname);

            if (cr.Errors.HasErrors)
            {
                Console.WriteLine(string.Format("Compiling Error：{0}", fullname));
                foreach (CompilerError err in cr.Errors)
                {
                    Console.Write("Error: ");
                    Console.WriteLine(err.ErrorText);
                }
            }
            else
            {
                List<SemanticShader> semanticShaderList = new List<SemanticShader>();
                Assembly assembly = cr.CompiledAssembly;
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(ShaderCode)))
                    {
                        ShaderCode shaderCode = Activator.CreateInstance(type) as ShaderCode;
                        SemanticShader semanticShader = shaderCode.Dump(fullname);
                        semanticShaderList.Add(semanticShader);
                    }
                }

                //var semanticShaderList =
                //    from type in cr.CompiledAssembly.GetTypes()
                //    where type.IsSubclassOf(typeof(ShaderCode))
                //    select (Activator.CreateInstance(type) as ShaderCode).Dump(fullname);

                foreach (var item in semanticShaderList)
                {
                    item.Dump2File();
                }
            }
        }
    }
}
