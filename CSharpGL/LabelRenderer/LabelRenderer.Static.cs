using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class LabelRenderer
    {

        private static ShaderCode[] staticShaderCodes;
        private static PropertyNameMap staticMap;

        static LabelRenderer()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\Label.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\Label.frag"), ShaderType.FragmentShader);
            LabelRenderer.staticShaderCodes = shaderCodes;

            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            LabelRenderer.staticMap = map;
        }

    }
}
