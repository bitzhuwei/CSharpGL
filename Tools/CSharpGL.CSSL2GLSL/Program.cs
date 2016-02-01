using CSharpShadingLanguage;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
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
        class SemanticShaderInfo
        {
            public SemanticShader shader;
            public bool codeUpdated;
        }
        class TranslationInfo
        {
            public string fullname;
            public CompilerErrorCollection errors;
            public IList<SemanticShaderInfo> semanticShaderList = new List<SemanticShaderInfo>();

            public int GetUpdatedShaderCount()
            {
                if (errors != null)
                {
                    return 0;
                }
                else
                {
                    return (from item in this.semanticShaderList where item.codeUpdated select item).Count();
                }
            }

            public int GetCompiledShaderCount()
            {
                if (errors != null)
                {
                    return 0;
                }
                else
                {
                    return this.semanticShaderList.Count;
                }
            }
            public void Append(StringBuilder builder, int preEmptySpace)
            {
                PrintPreEmptySpace(builder, preEmptySpace);
                builder.AppendFormat("--> Translating {0}", fullname); builder.AppendLine();
                if (errors != null)
                {
                    PrintPreEmptySpace(builder, preEmptySpace);
                    builder.AppendFormat(string.Format("Compiling Errors:")); builder.AppendLine();
                    foreach (CompilerError err in errors)
                    {
                        PrintPreEmptySpace(builder, preEmptySpace + 4);
                        builder.AppendFormat("Error: "); builder.AppendFormat(err.ErrorText); builder.AppendLine();
                    }
                }
                else
                {
                    PrintPreEmptySpace(builder, preEmptySpace);
                    builder.AppendFormat("{0} CSSL shaders:", this.semanticShaderList.Count); builder.AppendLine();
                    foreach (var item in semanticShaderList)
                    {
                        PrintPreEmptySpace(builder, preEmptySpace + 4);
                        builder.AppendFormat("{0} [{1}] to [{2}] OK!",
                            item.codeUpdated ? "Dump" : "Not need to dump",
                            item.shader.ShaderCode.GetType().Name, item.shader.ShaderCode.GetShaderFilename()); builder.AppendLine();
                    }
                }
            }

            private static void PrintPreEmptySpace(StringBuilder builder, int preEmptySpace)
            {
                for (int i = 0; i < preEmptySpace; i++)
                {
                    builder.Append(" ");
                }
            }
        }

        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            string logFullname = string.Empty;

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
                List<TranslationInfo> translationInfoList = new List<TranslationInfo>();
                foreach (var fullname in files)
                {
                    TranslationInfo translationInfo = TranslateCSharpShaderLanguage2GLSL(fullname);
                    translationInfoList.Add(translationInfo);
                }

                builder.AppendFormat("Directory: {0}", directoryName); builder.AppendLine();
                var foundCSSLCount = (from item in translationInfoList select item.GetCompiledShaderCount()).Sum();
                var updatedCSSLCount = (from item in translationInfoList select item.GetUpdatedShaderCount()).Sum();
                builder.AppendFormat("Found {0} CSSL shaders, and {1} of them are dumped to GLSL as needed.",
                    foundCSSLCount, updatedCSSLCount);
                builder.AppendLine();
                foreach (var item in translationInfoList)
                {
                    item.Append(builder, 4);
                }
                builder.AppendFormat("Translation all done!"); builder.AppendLine();

                string time = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                string logName = string.Format("CSSL2GLSLDump{0}.log", time);
                logFullname = Path.Combine(Environment.CurrentDirectory, logName);

            }
            catch (Exception e)
            {
                builder.AppendFormat("*********************Translation break off!*********************"); builder.AppendLine();
                builder.AppendFormat("Exception for CSSL2GLSL:"); builder.AppendLine();
                builder.AppendFormat(e.ToString()); builder.AppendLine();
            }

            File.WriteAllText(logFullname, builder.ToString());
            Process.Start("explorer", logFullname);
            Process.Start("explorer", "/select," + logFullname);
        }


        private static TranslationInfo TranslateCSharpShaderLanguage2GLSL(string fullname)
        {
            TranslationInfo translationInfo = new TranslationInfo() { fullname = fullname, };

            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();

            CompilerParameters objCompilerParameters = new CompilerParameters();
            objCompilerParameters.ReferencedAssemblies.Add("CSharpShaderLanguage.dll");
            objCompilerParameters.GenerateExecutable = false;
            objCompilerParameters.GenerateInMemory = true;
            objCompilerParameters.IncludeDebugInformation = true;
            CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromFile(
                objCompilerParameters, fullname);

            if (cr.Errors.HasErrors)
            {
                translationInfo.errors = cr.Errors;
            }
            else
            {
                //List<SemanticShader> semanticShaderList = new List<SemanticShader>();
                //Assembly assembly = cr.CompiledAssembly;
                //Type[] types = assembly.GetTypes();
                //foreach (var type in types)
                //{
                //    if (type.IsSubclassOf(typeof(CSShaderCode)))
                //    {
                //        CSShaderCode shaderCode = Activator.CreateInstance(type) as CSShaderCode;
                //        SemanticShader semanticShader = shaderCode.Dump(fullname);
                //        semanticShaderList.Add(semanticShader);
                //    }
                //}

                //foreach (var item in semanticShaderList)
                //{
                //    SemanticShaderInfo info = new SemanticShaderInfo();
                //    info.codeUpdated = item.Dump2File();
                //    info.shader = item;
                //    translationInfo.semanticShaderList.Add(info);
                //}

                // 下面是Linq的写法。
                var result = from semanticShader in
                                 (from type in cr.CompiledAssembly.GetTypes()
                                  where type.IsSubclassOf(typeof(CSShaderCode))
                                  select (Activator.CreateInstance(type) as CSShaderCode).Dump(fullname))
                             select new SemanticShaderInfo() 
                             { codeUpdated = semanticShader.Dump2File(), shader = semanticShader };

                translationInfo.semanticShaderList = result.ToList();
            }

            return translationInfo;
        }
    }
}
