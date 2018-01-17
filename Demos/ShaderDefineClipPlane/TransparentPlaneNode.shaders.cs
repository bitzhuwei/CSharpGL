using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShaderDefineClipPlane
{
    partial class TransparentPlaneNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec3 inColor;

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;

out vec3 passColor;

void main()
{
    gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0);

    passColor = inColor;
}
";

        private const string fragmentCode = @"#version 150

in vec3 passColor;

out vec4 outColor;

void main()
{
    if (int(gl_FragCoord.x - 0.5) % 2 == 1 && int(gl_FragCoord.y - 0.5) % 2 != 1) discard;
    if (int(gl_FragCoord.x - 0.5) % 2 != 1 && int(gl_FragCoord.y - 0.5) % 2 == 1) discard;

    outColor = vec4(passColor, 1.0);
}
";
    }
}
