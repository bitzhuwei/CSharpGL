using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMSectionNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;

uniform mat4 mvpMat;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
}
";

        private const string fragmentCode = @"#version 150

uniform vec3 color;

out vec4 outColor;

void main() {
    outColor = vec4(color, 1.0);
}
";

    }
}
