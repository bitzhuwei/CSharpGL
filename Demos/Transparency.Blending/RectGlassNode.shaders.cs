using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Transparency.Blending
{
    partial class RectGlassNode
    {
        private const string vert = @"#version 150

in vec3 inPosition;

uniform mat4 mvpMat;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
}
";

        private const string frag = @"#version 150

uniform vec4 color = vec4(1, 0, 0, 0.2);
uniform vec4 backgroundColor;

out vec4 outColor;

void main() {
    outColor = color + (1 - color.a) * backgroundColor;
}
";

    }
}
