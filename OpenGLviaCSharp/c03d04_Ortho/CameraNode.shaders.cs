using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d04_Ortho
{
    partial class CameraNode
    {
        private const string vertexCode = @"
#version 150

in vec3 inPosition;

uniform mat4 mvpMatrix;

void main() {
    gl_Position = mvpMatrix * vec4(inPosition, 1.0); 
}
";

        private const string fragmnetCode = @"
#version 150

uniform vec4 color = vec4(1, 1, 1, 1); // default: red color.

uniform bool halfTransparent = false;

out vec4 outColor;

void main() {
    if (halfTransparent) {
        if (int(gl_FragCoord.x - 0.5) % 2 == 1 && int(gl_FragCoord.y - 0.5) % 2 == 1) discard;
        if (int(gl_FragCoord.x - 0.5) % 2 != 1 && int(gl_FragCoord.y - 0.5) % 2 != 1) discard;
    }

    outColor = color;
}
";
    }
}
