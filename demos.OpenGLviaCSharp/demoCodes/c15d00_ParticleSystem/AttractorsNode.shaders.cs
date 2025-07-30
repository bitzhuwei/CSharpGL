using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d00_ParticleSystem {
    partial class AttractorsNode {
        private const string vertexCode = @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMat;

out vec3 passColor;

void main(void)
{
    gl_Position = mvpMat * vec4(inPosition, 1.0);

    passColor = inColor;
}
";

        private const string fragmentCode = @"#version 150 core

out vec4 outColor;

in vec3 passColor;

void main(void)
{
    outColor = vec4(passColor, 1.0);
}
";
    }
}
