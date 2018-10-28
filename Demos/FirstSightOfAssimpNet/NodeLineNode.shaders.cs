using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    partial class NodeLineNode
    {

        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec3 inColor;
in int inBoneIndex;

uniform mat4 mvpMat;
const int MAX_BONES = 100;
uniform mat4 bones[MAX_BONES];
uniform bool animation;

out vec3 passColor;

void main()
{
    if (inBoneIndex >= 0 && animation) {
        gl_Position = mvpMat * bones[inBoneIndex] * vec4(0,0,0, 1.0);
    }
    else {
        gl_Position = mvpMat * vec4(inPosition, 1.0);
    }

    passColor = inColor;

    gl_PointSize = 16;
}
";
        private const string fragmentCode = @"#version 150

in vec3 passColor;

out vec4 outColor;

void main()
{
    outColor = vec4(passColor, 1.0);
}
";

    }
}
