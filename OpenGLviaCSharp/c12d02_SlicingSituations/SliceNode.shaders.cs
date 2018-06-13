using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d02_SlicingSituations
{
    partial class SliceNode
    {
        private const string vertexCode = @"
#version 150

in vec3 inPosition;

uniform mat4 mvpMatrix;

void main() {
    gl_Position = mvpMatrix * vec4(inPosition, 1.0); 
}
";

        private const string fragmentCode = @"
#version 150

uniform vec3 color = vec3(1, 1, 1);

out vec4 outColor;

void main() {
    if (int(gl_FragCoord.x - 0.5) % 2 == 1 && int(gl_FragCoord.y - 0.5) % 2 == 1) discard;
    if (int(gl_FragCoord.x - 0.5) % 2 != 1 && int(gl_FragCoord.y - 0.5) % 2 != 1) discard;

    outColor = vec4(color, 1.0);
}
";
    }
}
