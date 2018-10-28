using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class NodePointNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;

uniform mat4 mvpMat;

void main()
{
    gl_Position = mvpMat * vec4(inPosition, 1.0);

    gl_PointSize = 16;
}
";

        private const string fragmentCode = @"#version 150

uniform vec3 diffuseColor;

out vec4 outColor;

void main()
{
    outColor = vec4(diffuseColor, 1.0);
}
";

    }
}
