using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c01d01PropertyGrid
{
    partial class CubeNode
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

uniform vec4 color = vec4(1, 0, 0, 1); // default: red color.

out vec4 outColor;

void main() {
    outColor = color;
}
";
    }
}
