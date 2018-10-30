using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gocator
{
    partial class NodePointNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMat;

out vec3 passColor;

void main()
{
    gl_Position = mvpMat * vec4(inPosition, 1.0);
    passColor = inColor;
}
";

        private const string fragmentCode = @"#version 150

in vec3 passColor;
uniform bool nothing = false;

out vec4 outColor;

void main()
{
    if (nothing) { outColor = vec4(1,1,1,1); }
    else {
    outColor = vec4(passColor, 1.0);
    }
}
";

    }
}
