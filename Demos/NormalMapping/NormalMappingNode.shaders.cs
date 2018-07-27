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

out vec4 fragColor;

struct DirectionalLight
{
    vec3 color;
    float ambient;
    float diffuse;
    vec3 direction;
};

uniform DirectionalLight light;
uniform sampler2D texColor;
uniform sampler2D gShadowMap;
uniform sampler2D gNormalMap;
uniform vec3 eyeWorldPos;
uniform float gMatSpecular = 1;
uniform float specularPower = 1;

vec4 CalcDirectionalLight(vec3 normal)
{
    vec4 ambient = vec4(light.color * light.ambient, 1.0f);
    float diffuseFactor = dot(normal, -light.direction);

    vec4 difuse  = vec4(0, 0, 0, 0);
    vec4 specular = vec4(0, 0, 0, 0);

    if (diffuseFactor > 0) {
        difuse = vec4(light.color * light.diffuse * diffuseFactor, 1.0f);

        vec3 v2e = normalize(eyeWorldPos - passWorldPos);
        vec3 lightReflect = normalize(reflect(light.direction, normal));
        float specularFactor = dot(v2e, lightReflect);
        if (specularFactor > 0) {
            specularFactor = pow(specularFactor, specularPower);
            specular = vec4(light.color * gMatSpecular * specularFactor, 1.0f);
        }
    }

    return (ambient + difuse + specular);
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
    vec4 lightColor = CalcDirectionalLight(normal);

    vec4 sampledColor = texture2D(texColor, passTexCoord.xy);
    fragColor = sampledColor * lightColor;
}
";
    }
}
