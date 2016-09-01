using System.IO;

namespace CSharpGL.Demos
{
    partial class ShaderToyRenderer
    {
        private static readonly IBufferable staticBufferable = new Cube();

        private static readonly ShaderCode[] staticShaderCodes = new ShaderCode[]
        {
            new ShaderCode(File.ReadAllText(@"shaders\ShaderToy.vert"), ShaderType.VertexShader),
            new ShaderCode(File.ReadAllText(@"shaders\ShaderToy.frag"), ShaderType.FragmentShader),
        };

        private static readonly PropertyNameMap staticPropertyNameMap = new PropertyNameMap(
            new string[] { "in_Position", },
            new string[] { Cube.strPosition, });
    }
}