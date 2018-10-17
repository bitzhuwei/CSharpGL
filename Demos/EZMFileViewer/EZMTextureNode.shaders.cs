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
in vec3 inNormal;
in vec2 inUV;
in vec4 inBlendWeights;
in ivec4 inBlendIndices;

uniform mat4 projectionMat;
uniform mat4 mvMat;
// glm.transpose(glm.inverse(mvMat))
uniform mat3 normalMat;
uniform mat4 bones[UNDEFINED_BONE_COUNT];

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
        blendNormal += (bones[index] * vec4(inNormal, 0.0)).xyz * inBlendWeights[i];
    }

    // transform vertex' position from model space to clip space.
    gl_Position = projectionMat * vec4((mvMat * inPos).xyz, 1.0);

    passNormal = normalize(normalMat * blendNormal);
    passUV = inUV;
}
";

        private const string fragmentCode = @"#version 150

in vec3 passPosition;
in vec3 passNormal;
in vec2 passUV;

uniform sampler2D textureMap;
// 0-> submesh has texture, 1-> submesh has no texture.
uniform float useDefault;
uniform vec3 light_position;
uniform mat4 mvMat;

///// <summary>
///// ambient color of whole scene.
///// </summary>
//[Uniform]
//vec3 ambientColor = vec3(0.2);
///// <summary>
///// vertex' properties of refelcting light.
///// </summary>
//[Uniform]
//Material material = new Material(vec3(1), vec3(1), vec3(1), 6.0, 10);
///// <summary>
///// white light.
///// </summary>
//[Uniform]
//Light light = new Light(LightType.SpotLight, vec3(1), vec3(1), vec3(1), vec3(0), 0.5, 1);
//[Uniform]
//float constantAttenuation = 1.0f;
//[Uniform]
//float linearAttenuation = 0.0001f;
//[Uniform]
//float quadraticAttenuation = 0.0001f;

out vec4 outColor;

void main()
{
    vec4 vEyeSpaceLightPos = mvMat * vec4(light_position, 1.0);
    vec3 L = vEyeSpaceLightPos.xyz - passPosition;
    L = normalize(L);
    float diffuse = max(0, dot(normalize(passNormal), L));

    outColor = diffuse * mix(texture(textureMap, passUV), vec4(1), useDefault);
}
";

    }
}
