using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace NormalMapping
{
    partial class NormalMappingNode
    {
        private const string vertexCode = @"#version 330

in vec3 inPosition;
in vec3 inNormal;
in vec3 inTangent;
in vec2 inTexCoord;

uniform mat4 mvpMat;
uniform mat4 modelMat;

out vec3 passWorldPos;
out vec3 passNormal;
out vec3 passTangent;
out vec2 passTexCoord;

void main()
{
    gl_Position  = mvpMat * vec4(inPosition, 1.0);
    passWorldPos = (modelMat * vec4(inPosition, 1.0)).xyz;
    passNormal   = (modelMat * vec4(inNormal, 0.0)).xyz;
    passTangent  = (modelMat * vec4(inTangent, 0.0)).xyz;
    passTexCoord = inTexCoord;
}
";

        private const string fragmentCode = @"#version 330

in vec2 passTexCoord;
in vec3 passNormal;
in vec3 passWorldPos;
in vec3 passTangent;

out vec4 FragColor;

struct BaseLight
{
    vec3 Color;
    float AmbientIntensity;
    float DiffuseIntensity;
};

struct DirectionalLight
{
    BaseLight Base;
    vec3 Direction;
};

uniform DirectionalLight gDirectionalLight;
uniform sampler2D gColorMap;
uniform sampler2D gShadowMap;
uniform sampler2D gNormalMap;
uniform vec3 gEyeWorldPos;
uniform float gMatSpecularIntensity;
uniform float gSpecularPower;

vec4 CalcLightInternal(BaseLight Light, vec3 LightDirection, vec3 normal, float ShadowFactor)
{
    vec4 AmbientColor = vec4(Light.Color * Light.AmbientIntensity, 1.0f);
    float DiffuseFactor = dot(normal, -LightDirection);

    vec4 DiffuseColor  = vec4(0, 0, 0, 0);
    vec4 SpecularColor = vec4(0, 0, 0, 0);

    if (DiffuseFactor > 0) {
        DiffuseColor = vec4(Light.Color * Light.DiffuseIntensity * DiffuseFactor, 1.0f);

        vec3 VertexToEye = normalize(gEyeWorldPos - passWorldPos);
        vec3 LightReflect = normalize(reflect(LightDirection, normal));
        float SpecularFactor = dot(VertexToEye, LightReflect);
        if (SpecularFactor > 0) {
            SpecularFactor = pow(SpecularFactor, gSpecularPower);
            SpecularColor = vec4(Light.Color * gMatSpecularIntensity * SpecularFactor, 1.0f);
        }
    }

    return (AmbientColor + ShadowFactor * (DiffuseColor + SpecularColor));
}

vec4 CalcDirectionalLight(vec3 normal)
{
    return CalcLightInternal(gDirectionalLight.Base, gDirectionalLight.Direction, normal, 1.0);
}

vec3 CalcBumpedNormal()
{
    vec3 normal = normalize(passNormal);
    vec3 tangent = normalize(passTangent);
    tangent = normalize(tangent - dot(tangent, normal) * normal);
    vec3 bitangent = cross(tangent, normal);
    vec3 bumpMapNormal = texture(gNormalMap, passTexCoord).xyz;
    bumpMapNormal = 2.0 * bumpMapNormal - vec3(1.0, 1.0, 1.0);
    mat3 TBN = mat3(tangent, bitangent, normal);
    vec3 newNormal = TBN * bumpMapNormal;
    return normalize(newNormal);
}

void main()
{
    vec3 normal = CalcBumpedNormal();
    vec4 TotalLight = CalcDirectionalLight(normal);

    vec4 SampledColor = texture2D(gColorMap, passTexCoord.xy);
    FragColor = SampledColor * TotalLight;
}
";
    }
}
