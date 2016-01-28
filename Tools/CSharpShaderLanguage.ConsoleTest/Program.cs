using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShaderLanguage.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] csharpShaders = new string[] { "DemoVert.cs", "DemoFrag.cs" };
            // 1.CSharpCodePrivoder
            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();

            // 2.ICodeComplier
            //ICodeCompiler objICodeCompiler = objCSharpCodePrivoder.CreateCompiler();

            // 3.CompilerParameters
            CompilerParameters objCompilerParameters = new CompilerParameters();
            objCompilerParameters.ReferencedAssemblies.Add("System.dll");
            objCompilerParameters.GenerateExecutable = false;
            objCompilerParameters.GenerateInMemory = true;

            // 4.CompilerResults
            //CompilerResults cr = objICodeCompiler.CompileAssemblyFromSource(objCompilerParameters, GenerateCode());
            CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromFile(objCompilerParameters, csharpShaders);

            if (cr.Errors.HasErrors)
            {
                Console.WriteLine("编译错误：");
                foreach (CompilerError err in cr.Errors)
                {
                    Console.WriteLine(err.ErrorText);
                }
            }
            else
            {
                // 通过反射，调用HelloWorld的实例
                Assembly objAssembly = cr.CompiledAssembly;
                object objHelloWorld = objAssembly.CreateInstance("CSharpShaderLanguage.ConsoleTest.DemoVert");
                MethodInfo objMI = objHelloWorld.GetType().GetMethod("DemoOuput");

                Console.WriteLine(objMI.Invoke(objHelloWorld, null));
            }

            Console.ReadLine();
        }
    }
}
