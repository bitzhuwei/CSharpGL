using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilTest
{
    partial class HowStencilWorkNode
    {
        private const string vertexCode = @"#version 150 core
    in vec3 position;
    in vec3 color;
    in vec2 texcoord;
    out vec3 Color;
    out vec2 Texcoord;
    uniform mat4 model;
    uniform mat4 view;
    uniform mat4 proj;
    uniform vec3 overrideColor;
    void main()
    {
        Color = overrideColor * color;
        Texcoord = texcoord;
        gl_Position = proj * view * model * vec4(position, 1.0);
    }
";

        private const string fragmentCode = @"#version 150 core
    in vec3 Color;
    in vec2 Texcoord;
    out vec4 outColor;
    uniform sampler2D texKitten;
    uniform sampler2D texPuppy;
    void main()
    {
        outColor = vec4(Color, 1.0) * mix(texture(texKitten, Texcoord), texture(texPuppy, Texcoord), 0.5);
    }
";
    }
}
