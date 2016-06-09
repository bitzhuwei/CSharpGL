using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    class SimplexNoiseRenderer : Renderer
    {
        static readonly IBufferable staticBufferable = new Sphere();
        static readonly ShaderCode[] staticShaderCodes = new ShaderCode[]
        {
            new ShaderCode(File.ReadAllText(@"13SimplexNoise\SimplexNoise.vert"), ShaderType.VertexShader),
            new ShaderCode(File.ReadAllText(@"13SimplexNoise\SimplexNoise.frag"), ShaderType.FragmentShader),
        };
        static readonly PropertyNameMap staticPropertyNameMap = new PropertyNameMap(
            new string[] { "position", "color", },
            new string[] { Sphere.strPosition, Sphere.strColor });

        public SimplexNoiseRenderer()
            : base(staticBufferable, staticShaderCodes, staticPropertyNameMap) { }

    }
}
