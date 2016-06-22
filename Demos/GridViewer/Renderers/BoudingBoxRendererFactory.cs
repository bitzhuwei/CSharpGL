using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public static class BoudingBoxRendererFactory
    {

        /// <summary>
        /// get a bounding box renderer.
        /// </summary>
        /// <param name="lengths">bounding box's length at x, y, z axis.</param>
        /// <returns></returns>
        public static Renderer GetBoundingBoxRenderer(vec3 lengths)
        {
            var bufferable = new BoundingBox(lengths);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(
                @"shaders\BoundingBox.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(
                @"shaders\BoundingBox.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", BoundingBox.strPosition);
            var result = new Renderer(bufferable, shaderCodes, map, new PolygonModeSwitch(PolygonModes.Lines), new PolygonOffsetFillSwitch());

            return result;
        }

    }
}
