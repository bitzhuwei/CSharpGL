using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMDualQuatNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec2 inUV;
in vec4 inBlendWeights;
in ivec4 inBlendIndices;

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;
uniform vec4 Bones[UNDEFINED_BONE_COUNT];

out vec2 passUV;

mat4 dualQuatToMatrix(vec4 Qn, vec4 Qd)
{
    float len2 = dot(Qn, Qn);
    float w = Qn.w, x = Qn.x, y = Qn.y, z = Qn.z;
    float t0 = Qd.w, t1 = Qd.x, t2 = Qd.y, t3 = Qd.z;
    vec4 col0 = vec4(w * w + x * x - y * y - z * z,
        2 * x * y + 2 * w * z,
        2 * x * z - 2 * w * y,
        0) / len2;
    vec4 col1 = vec4(2 * x * y - 2 * w * z,
        w * w + y * y - x * x - z * z,
        2 * y * z + 2 * w * x,
        0) / len2;
    vec4 col2 = vec4(2 * x * z + 2 * w * y,
        2 * y * z - 2 * w * x,
        w * w + z * z - x * x - y * y,
        0) / len2;
    vec4 col3 = vec4(-2 * t0 * x + 2 * w * t1 - 2 * t2 * z + 2 * y * t3,
        -2 * t0 * y + 2 * t1 * z - 2 * x * t3 + 2 * w * t2,
        -2 * t0 * z + 2 * x * t2 + 2 * w * t3 - 2 * t1 * y,
        len2) / len2;
    mat4 m = mat4(col0, col1, col2, col3);

    return m;
}

void main()
{
    vec4 blendPosition = vec4(0);
    vec3 blendNormal = vec3(0);
    vec4 blendDQ[2];

    //here we check the dot product between the two quaternions
    float yc = 1.0, zc = 1.0, wc = 1.0;

    //if the dot product is < 0 they are opposite to each other
    //hence we multiply the -1 which would subtract the blended result
    if (dot(Bones[inBlendIndices.x * 2], Bones[inBlendIndices.y * 2]) < 0.0)
        yc = -1.0;

    if (dot(Bones[inBlendIndices.x * 2], Bones[inBlendIndices.z * 2]) < 0.0)
        zc = -1.0;

    if (dot(Bones[inBlendIndices.x * 2], Bones[inBlendIndices.w * 2]) < 0.0)
        wc = -1.0;

    for (int i = 0; i < 4; i++)
    {
        int index = inBlendIndices[i];
        blendDQ[0] += (Bones[index * 2]) * inBlendWeights[i];
        blendDQ[1] += (Bones[index * 2 + 1]) * inBlendWeights[i];
    }

    //get the skinning matrix from the dual quaternion
    mat4 skinTransform = dualQuatToMatrix(blendDQ[0], blendDQ[1]);
    blendPosition = skinTransform * vec4(inPosition, 1.0);

    // transform vertex' position from model space to clip space.
    gl_Position = projectionMat * vec4((viewMat * modelMat * blendPosition).xyz, 1.0);

    passUV = inUV;
}
";

        private const string fragmentCode = @"#version 150

in vec2 passUV;

uniform sampler2D textureMap;

out vec4 outColor;

void main()
{
    if (int(gl_FragCoord.x + gl_FragCoord.y) % 2 == 1) discard;

    outColor = texture(textureMap, passUV);
}
";

    }
}
