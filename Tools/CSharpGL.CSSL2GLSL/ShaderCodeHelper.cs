using CSharpShaderLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSL2GLSL
{
    static class ShaderCodeHelper
    {
        public static SemanticShader Dump(this ShaderCode shaderCode, string fullname)
        {
            if (shaderCode.GetType().IsSubclassOf(typeof(VertexShaderCode)))
            {
                return new SemanticVertexShader(shaderCode, fullname);
            }
            else if (shaderCode.GetType().IsSubclassOf(typeof(FragmentShaderCode)))
            {
                return new SemanticFragmentShader(shaderCode, fullname);
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

        public static string GetShaderFilename(this ShaderCode shaderCode)
        {
            Type type = shaderCode.GetType();

            string extensionName = string.Empty;
            if (type.IsSubclassOf(typeof(VertexShaderCode)))
            {
                extensionName = "vert";
            }
            else if (type.IsSubclassOf(typeof(FragmentShaderCode)))
            {
                extensionName = "frag";
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
