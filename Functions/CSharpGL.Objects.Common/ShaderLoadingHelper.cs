using CSharpGL.Objects.ModernRendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.Objects.Common
{
    public static class ShaderLoadingHelper
    {

        public static UniformNameMap LoadUniformNameMap(string shaderName)
        {
            string content = ManifestResourceLoader.LoadTextFile(string.Format(
                "{0}.{0}.UniformNameMap.xml", shaderName));

            UniformNameMap result = UniformNameMap.Parse(XElement.Parse(content));

            return result;
        }

        public static PropertyNameMap LoadPropertyNameMap(string shaderName)
        {
            string content = ManifestResourceLoader.LoadTextFile(string.Format(
                "{0}.{0}.PropertyNameMap.xml", shaderName));

            PropertyNameMap result = PropertyNameMap.Parse(XElement.Parse(content));

            return result;
        }

        public static CodeShader LoadShaderSourceCode(string shaderName, CodeShader.GLSLShaderType shaderType)
        {
            CodeShader result = null;

            switch (shaderType)
            {
                case CodeShader.GLSLShaderType.VertexShader:
                    result = new CodeShader(ManifestResourceLoader.LoadTextFile(string.Format(
                        "{0}.{0}.vert", shaderName)), CodeShader.GLSLShaderType.VertexShader);
                    break;
                case CodeShader.GLSLShaderType.GeometryShader:
                    result = new CodeShader(ManifestResourceLoader.LoadTextFile(string.Format(
                        "{0}.{0}.geom", shaderName)), CodeShader.GLSLShaderType.GeometryShader);
                    break;
                case CodeShader.GLSLShaderType.FragmentShader:
                    result = new CodeShader(ManifestResourceLoader.LoadTextFile(string.Format(
                        "{0}.{0}.frag", shaderName)), CodeShader.GLSLShaderType.FragmentShader);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
