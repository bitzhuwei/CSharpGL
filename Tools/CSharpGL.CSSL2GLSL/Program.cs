using CSharpShaderLanguage;
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
            public List<SemanticShaderInfo> semanticShaderList = new List<SemanticShaderInfo>();

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
            //PrintComponents();
            //return;
            StringBuilder builder = new StringBuilder();

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
                var CSSLCount = (from item in translationInfoList
                                 select item.GetCompiledShaderCount()).Sum();
                builder.AppendFormat("Found {0} CSSL shaders.", CSSLCount); builder.AppendLine();
                foreach (var item in translationInfoList)
                {
                    item.Append(builder, 4);
                }
                builder.AppendFormat("Translation all done!"); builder.AppendLine();
            }
            catch (Exception e)
            {
                builder.AppendFormat("*********************Translation break off!*********************"); builder.AppendLine();
                builder.AppendFormat("Exception for CSSL2GLSL:"); builder.AppendLine();
                builder.AppendFormat(e.ToString()); builder.AppendLine();
            }

            string time = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            string logName = string.Format("CSSL2GLSLDump{0}.log", time);
            string logFullname = Path.Combine(Environment.CurrentDirectory, logName);
            File.WriteAllText(logFullname, builder.ToString());
            Process.Start("explorer", logFullname);
            Process.Start("explorer", "/select," + logFullname);
        }

        /// <summary>
        /// 给出vec2 vec3 vec4内部所有可能的组合形式。运行一下看结果就明白了，不用啃这个代码。
        /// </summary>
        private static void PrintComponents()
        {
            List<char[]> list = new List<char[]>();
            list.Add(new char[] { 'x', 'y', 'z', 'w' });
            list.Add(new char[] { 'r', 'g', 'b', 'a' });
            list.Add(new char[] { 's', 't', 'p', 'q' });
            for (int vLength = 2; vLength < 5; vLength++)
            {
                StringBuilder builder = new StringBuilder();

                foreach (var components in list)
                {
                    for (int i = 0; i < vLength; i++)
                    {
                        builder.AppendFormat("public float {0} {{ get {{ return 0.0f; }} }}", components[i], vLength);
                        builder.AppendLine();
                    }
                    builder.AppendLine();

                    for (int i = 0; i < vLength; i++)
                    {
                        for (int j = 0; j < vLength; j++)
                        {
                            builder.AppendFormat("public vec2 {0}{1} {{ get {{ return default(vec2); }} }}", components[i], components[j], vLength);
                            builder.AppendLine();
                        }
                    }
                    builder.AppendLine();

                    if (vLength < 3) { continue; }

                    for (int i = 0; i < vLength; i++)
                    {
                        for (int j = 0; j < vLength; j++)
                        {
                            for (int k = 0; k < vLength; k++)
                            {
                                builder.AppendFormat("public vec3 {0}{1}{2} {{ get {{ return default(vec3); }} }}", components[i], components[j], components[k], vLength);
                                builder.AppendLine();
                            }
                        }
                    }
                    builder.AppendLine();

                    if (vLength < 4) { continue; }

                    for (int i = 0; i < vLength; i++)
                    {
                        for (int j = 0; j < vLength; j++)
                        {
                            for (int k = 0; k < vLength; k++)
                            {
                                for (int m = 0; m < vLength; m++)
                                {
                                    builder.AppendFormat("public vec4 {0}{1}{2}{3} {{ get {{ return default(vec4); }} }}", components[i], components[j], components[k], components[m], vLength);
                                    builder.AppendLine();
                                }
                            }
                        }
                    }

                }

                builder.AppendLine();

                File.WriteAllText("vec" + vLength + ".txt", builder.ToString());
            }
        }

        private static TranslationInfo TranslateCSharpShaderLanguage2GLSL(string fullname)
        {
            TranslationInfo translationInfo = new TranslationInfo() { fullname = fullname, };

            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();

            CompilerParameters objCompilerParameters = new CompilerParameters();
            //objCompilerParameters.ReferencedAssemblies.Add("System.dll");
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
                    SemanticShaderInfo info = new SemanticShaderInfo();
                    info.codeUpdated = item.Dump2File();
                    info.shader = item;
                    translationInfo.semanticShaderList.Add(info);
                }

            }

            return translationInfo;
        }
    }
}
