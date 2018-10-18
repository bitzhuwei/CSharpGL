using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMTextureNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
//in vec3 inNormal;
in vec2 inUV;
in vec4 inBlendWeights;
in ivec4 inBlendIndices;

uniform mat4 projectionMat;
uniform mat4 mvMat;
// glm.transpose(glm.inverse(mvMat))
uniform mat3 normalMat;
uniform mat4 bones[UNDEFINED_BONE_COUNT];
uniform bool useBones = true;

// position in eye space.
out vec3 passPosition;
// normal in eye space.
out vec3 passNormal;
out vec2 passUV;

void main()
{
    vec4 blendPosition = vec4(0);
    vec3 blendNormal = vec3(0);
    vec4 inPos = vec4(inPosition, 1.0);

    for (int i = 0; i < 4; i++)
    {
        int index = inBlendIndices[i];
        blendPosition += (bones[index] * inPos) * inBlendWeights[i];
//        blendNormal += (bones[index] * vec4(inNormal, 0.0)).xyz * inBlendWeights[i];
    }

    if (useBones) {
        // transform vertex' position from model space to clip space.
        gl_Position = projectionMat * vec4((mvMat * blendPosition).xyz, 1.0);
    }
    else {
        gl_Position = projectionMat * mvMat * inPos;
    }

//    passNormal = normalize(normalMat * blendNormal);
    passUV = inUV;
}
";

        private const string fragmentCode = @"#version 150

in vec2 passUV;

uniform sampler2D textureMap;

out vec4 outColor;

void main()
{
    outColor = texture(textureMap, passUV);
}
";

    }
}
