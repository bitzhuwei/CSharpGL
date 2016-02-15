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

        //public SemanticField(FieldQualifier varQualifier, Type type, string varName)
        public SemanticField(QualifierAttribute attribute, Type type, string varName)
        {
            //this.varQualifier = varQualifier;
            this.attribute = attribute;
            this.varType = type;
            this.varName = varName;
        }

        public string Dump()
        {
            StringBuilder builder = new StringBuilder();
            //builder.Append(this.varQualifier.ToString());
            string typeName = string.Empty;
            if (buildInTypeDict.TryGetValue(this.varType, out typeName))
            {
                builder.Append(this.attribute.NameInGLSL);// in/out/uniform/flat
                builder.Append(" ");
                builder.Append(typeName);// vec3
                builder.Append(" ");
                builder.Append(this.varName);// in_Position
                builder.Append(";");// ;
            }
            else// 自定义类型
            {
                builder.Append(this.attribute.NameInGLSL);// in/out/uniform/flat
                builder.Append(" ");
                builder.Append(this.varType.Name);// VS_GS_VERTEX
                builder.AppendLine();
                builder.Append("{");
                builder.AppendLine();
                foreach (var item in this.varType.GetFields())
                {
                    builder.Append("    ");
                    builder.Append(item.FieldType.Name);
                    builder.Append(" ");
                    builder.Append(item.Name);// in_Position
                    builder.Append(";");// ;
                    builder.AppendLine();
                }
                builder.Append("} ");
                builder.Append(this.varName);
                // todo: try add []
                builder.Append(";");
                builder.AppendLine();
            }


            return builder.ToString();
        }

        /// <summary>
        /// dict of (type, type name in glgl)
        /// </summary>
        static Dictionary<Type, string> buildInTypeDict = new Dictionary<Type, string>();

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
        }
    }

    public enum FieldQualifier
    {
        In,
        Out,
        Uniform,
    }
}
