using System.IO;
namespace CSharpGL.Demos
{
    /// <summary>
    /// This demo uses shade from [webgl-noise](https://github.com/ashima/webgl-noise)
    /// sunColor.grd是photoshop使用的渐变色定义。
    /// </summary>
    [DemoRenderer]
    partial class ShaderToyRenderer : Renderer
    {
        public static ShaderToyRenderer Create()
        {
            var model = new Cube();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\ShaderToy.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\ShaderToy.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", Cube.strPosition);
            var renderer = new ShaderToyRenderer(model, shaderCodes, map);
            renderer.ModelSize = model.Lengths;

            return renderer;
        }

        private ShaderToyRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
        }
    }
}