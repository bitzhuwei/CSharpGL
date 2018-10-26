using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    partial class BoneNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;

uniform mat4 mvpMat;
const int MAX_BONES = 100;
uniform mat4 bones[MAX_BONES];
uniform bool animation = true;

void main()
{
    if (animation) {
        mat4 boneMat = bones[gl_VertexID];
        gl_Position = mvpMat * boneMat * vec4(inPosition, 1.0);
    }
    else {
        gl_Position = mvpMat * vec4(inPosition, 1.0);
    }
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
