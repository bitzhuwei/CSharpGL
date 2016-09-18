using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    partial class SimplexNoiseRenderer
    {
        private static readonly IBufferable staticBufferable = new Sphere(1, 180, 360);

        private static readonly ShaderCode[] staticShaderCodes = new ShaderCode[]
        {
            new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.vert"), ShaderType.VertexShader),
            new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.frag"), ShaderType.FragmentShader),
        };

        private static readonly PropertyNameMap staticPropertyNameMap = new PropertyNameMap(
            new string[] { "in_Position", },
            new string[] { Sphere.strPosition, });
    }
}