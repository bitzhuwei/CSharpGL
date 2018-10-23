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
in vec2 inTexCoord;
in uvec4 inBoneIDs;
in vec4 inWeights;

uniform mat4 mvpMat;
const int MAX_BONES = 100;
uniform mat4 bones[MAX_BONES];

out vec2 passTexCoord;

void main()
{
    mat4 boneMat = bones[inBoneIDs[0]] * inWeights[0];
    boneMat += bones[inBoneIDs[1]] * inWeights[1];
    boneMat += bones[inBoneIDs[2]] * inWeights[2];
    boneMat += bones[inBoneIDs[3]] * inWeights[3];

    gl_Position = mvpMat * boneMat * vec4(inPosition, 1.0);
    passTexCoord = inTexCoord;
}
";

        private const string fragmentCode = @"#version 150

in vec2 passTexCoord;

uniform sampler2D textureMap;

out vec4 outColor;

void main()
{
    outColor = texture(textureMap, passTexCoord);
}
";

    }
}
