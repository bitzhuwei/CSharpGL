using CSharpShadingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSL2GLSL
{
    public static class ShaderCodeHelper
    {
        public static SemanticShader GetSemanticShader(this CSShaderCode shaderCode, CSSLFileGroup fullnames)
        {
            if (shaderCode.GetType().IsSubclassOf(typeof(VertexCSShaderCode)))
            {
                return new SemanticVertexShader(shaderCode, fullnames);
            }
            else if (shaderCode.GetType().IsSubclassOf(typeof(FragmentCSShaderCode)))
            {
                return new SemanticFragmentShader(shaderCode, fullnames);
            }
                else if (shaderCode.GetType().IsSubclassOf(typeof(GeometryCSShaderCode)))
            {
                return new SemanticGeometryShader(shaderCode, fullnames);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        ///// <summary>
        ///// 此类型的shader保存到GLSL文件时的扩展名。（不包含'.'）
        ///// </summary>
        //public abstract string ExtensionName { get; }

        public static string GetShaderFilename(this CSShaderCode shaderCode)
        {
            Type type = shaderCode.GetType();

            string extensionName = string.Empty;
            if (type.IsSubclassOf(typeof(VertexCSShaderCode)))
            {
                extensionName = "vert";
            }
            else if (type.IsSubclassOf(typeof(FragmentCSShaderCode)))
            {
                extensionName = "frag";
            }
            else if(type.IsSubclassOf(typeof(GeometryCSShaderCode)))
            {
                extensionName = "geom";
            }
            else
            {
                throw new NotImplementedException();
            }

            string name = type.Name;
            if (name.ToLower().EndsWith(extensionName.ToLower()))
            {
                name = name.Substring(0, name.Length - extensionName.Length) + "." + extensionName;
            }
            else
            {
                name = name + "." + extensionName;
            }

            return name;
        }
    }
}
