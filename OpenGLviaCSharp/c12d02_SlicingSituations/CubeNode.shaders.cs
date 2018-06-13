using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d02_SlicingSituations
{
    partial class CubeNode
    {
        private const string vertexCode = @"
#version 150

in vec3 inPosition;
in vec3 inColor;

out vec3 passColor;

uniform mat4 mvpMatrix;

void main() {
    gl_Position = mvpMatrix * vec4(inPosition, 1.0); 

    passColor = inColor;
}
";

        private const string fragmentCode = @"
#version 150

in vec3 passColor;

out vec4 outColor;

void main() {
    if (false) {
        if (int(gl_FragCoord.x - 0.5) % 2 == 1 && int(gl_FragCoord.y - 0.5) % 2 == 1) discard;
        if (int(gl_FragCoord.x - 0.5) % 2 != 1 && int(gl_FragCoord.y - 0.5) % 2 != 1) discard;
    }

    outColor = vec4(passColor, 1.0);
}
";
    }
}
