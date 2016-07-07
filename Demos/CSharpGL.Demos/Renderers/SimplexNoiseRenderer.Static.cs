using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer
    {
        static readonly IBufferable staticBufferable = new Sphere(1, 180, 360);
        static readonly ShaderCode[] staticShaderCodes = new ShaderCode[]
        {
            new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.vert"), ShaderType.VertexShader),
            new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.frag"), ShaderType.FragmentShader),
        };
        static readonly PropertyNameMap staticPropertyNameMap = new PropertyNameMap(
            new string[] { "in_Position", },
            new string[] { Sphere.strPosition, });


    }
}
