using CSharpShadingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSharpGL.CSSL2GLSL
{
    public class SemanticField
    {
        //private FieldQualifier varQualifier;
        private QualifierAttribute attribute;
        private Type varType;
        private string varName;
        private CSShaderCode shaderCode;

        //public SemanticField(FieldQualifier varQualifier, Type type, string varName)
        public SemanticField(QualifierAttribute attribute, Type type, string varName, CSShaderCode shaderCode)
        {
            //this.varQualifier = varQualifier;
            this.attribute = attribute;
            this.varType = type;
            this.varName = varName;
            this.shaderCode = shaderCode;
        }

        public string Dump()
        {
            StringBuilder builder = new StringBuilder();

            Queue<Type> dumpedType = new Queue<Type>();
            Queue<Type> undumpedType = new Queue<Type>();
            undumpedType.Enqueue(this.varType);
            while (undumpedType.Count > 0)
            {
                Type currentType = undumpedType.Dequeue();
                dumpedType.Enqueue(currentType);
                string typeName = string.Empty;
                if (buildInTypeDict.TryGetValue(currentType, out typeName))
                {
                    builder.Append(this.attribute.NameInGLSL);// in/out/uniform/flat
                    builder.Append(" ");
                    builder.Append(typeName);// vec3
                    builder.Append(" ");
                    builder.Append(this.varName);// in_Position

                    if (buildInDefaultableTypeDict.ContainsKey(currentType))
                    {
                        foreach (var item in this.shaderCode.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
                        {
                            if(item.Name == this.varName)
                            {
                                object obj = item.GetValue(this.shaderCode);
                                builder.Append(string.Format(" = {0}", obj));
                                break;
                            }
                        }
                    }
                           
                    builder.Append(";");// ;
                }
                else// 自定义类型
                {
                    builder.Append(this.attribute.NameInGLSL);// in/out/uniform/flat
                    builder.Append(" ");
                    if (this.varType.IsArray)
                    {
                        Type elementType = currentType.GetElementType();
                        builder.Append(elementType.Name);
                        builder.AppendLine();
                        builder.Append("{");
                        builder.AppendLine();
                        foreach (var item in elementType.GetFields(BindingFlags.Public | BindingFlags.Instance))
                        {
                            builder.Append("    ");
                            builder.Append(item.FieldType.Name);
                            builder.Append(" ");
                            builder.Append(item.Name);// in_Position
                            builder.Append(";");// ;
                            builder.AppendLine();

                            if ((!buildInTypeDict.ContainsKey(item.FieldType))//不是内置类型（需要解析）
                                && (!dumpedType.Contains(item.FieldType))//没有解析过（需要解析）
                                && (!undumpedType.Contains(item.FieldType)))//不在待解析队列
                            { undumpedType.Enqueue(item.FieldType); }
                        }
                        builder.Append("} ");
                        builder.Append(this.varName);
                        builder.Append("[];");
                        builder.AppendLine();
                    }
                    else
                    {
                        builder.Append(currentType.Name);
                        builder.AppendLine();
                        builder.Append("{");
                        builder.AppendLine();
                        foreach (var item in currentType.GetFields(BindingFlags.Public | BindingFlags.Instance))
                        {
                            builder.Append("    ");
                            builder.Append(item.FieldType.Name);
                            builder.Append(" ");
                            builder.Append(item.Name);// in_Position
                            builder.Append(";");// ;
                            builder.AppendLine();

                            if ((!buildInTypeDict.ContainsKey(item.FieldType))//不是内置类型（需要解析）
                                && (!dumpedType.Contains(item.FieldType))//没有解析过（需要解析）
                                && (!undumpedType.Contains(item.FieldType)))//不在待解析队列
                            { undumpedType.Enqueue(item.FieldType); }
                        }
                        builder.Append("} ");
                        builder.Append(this.varName);
                        builder.Append(";");
                        builder.AppendLine();
                    }
                }
            }


            return builder.ToString();
        }

        /// <summary>
        /// dict of (type, type name in glgl)
        /// </summary>
        static Dictionary<Type, string> buildInTypeDict = new Dictionary<Type, string>();
        static Dictionary<Type, string> buildInDefaultableTypeDict = new Dictionary<Type, string>();

        static SemanticField()
        {
            buildInTypeDict.Add(typeof(float), "float");
            buildInTypeDict.Add(typeof(int), "int");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.vec2), "vec2");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.vec3), "vec3");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.vec4), "vec4");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.mat2), "mat2");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.mat3), "mat3");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.mat4), "mat4");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.sampler1D), "sampler1D");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.sampler2D), "sampler2D");
            buildInTypeDict.Add(typeof(CSharpShadingLanguage.sampler3D), "sampler3D");

            buildInDefaultableTypeDict.Add(typeof(float), "0.0f");
            buildInDefaultableTypeDict.Add(typeof(int), "0");
        }

    }

    public enum FieldQualifier
    {
        /// <summary>
        /// in
        /// </summary>
        In,

        /// <summary>
        /// out
        /// </summary>
        Out,

        /// <summary>
        /// uniform
        /// </summary>
        Uniform,
    }
}
