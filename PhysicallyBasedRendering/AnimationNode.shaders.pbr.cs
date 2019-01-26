using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    partial class PBRNode
    {
        private const string PBRVertexCode = @"#version 330 core

layout(location = 0) in vec3 vPosition;
layout(location = 1) in vec2 vTexCoords;
layout(location = 2) in vec3 vNormal;


out vec2 TexCoords;
out vec3 WorldPos;
out vec3 WorldNormal;


uniform mat4 ModelMatrix;
uniform mat4 ViewMatrix;
uniform mat4 ProjMatrix;

void main()
{
    TexCoords = vTexCoords;
	WorldPos = vec3(ModelMatrix * vec4(vPosition, 1.0f));
	WorldNormal = mat3(ModelMatrix) * vNormal;
    gl_Position = ProjMatrix * ViewMatrix * vec4(WorldPos, 1.0f);
}
";

        private const string PBRFragmentCode = @"#version 330 core


in vec2 TexCoords;
in vec3 WorldPos;
in vec3 WorldNormal;

uniform vec3 lightPositions[4];
uniform vec3 lightColors[4];
uniform	vec3 cameraPos;
uniform samplerCube irradianceMap;
uniform samplerCube preflitterMap;
uniform	sampler2D brdfLUT;
uniform sampler2D albedoMap;
uniform sampler2D normalMap;
uniform sampler2D metallicMap;
uniform sampler2D roughnessMap;
uniform sampler2D aoMap;
const float	PI=3.14159265359;

out vec4 fColor;


//法线分布函数
float DistributionGGX(vec3 N, vec3 H, float roughness)
{
    float a = roughness * roughness;
    float a2 = a * a;
    float NdotH = max(dot(N, H), 0.0);
    float NdotH2 = NdotH * NdotH;
    float nom = a2;
    float denom = (NdotH2 * (a2 - 1.0) + 1.0);
    denom=PI * denom * denom;
    return nom / denom;
}


//幾何函数
float GeometrySchlickGGX(float NdotV, float roughness)
{
    float r = (roughness + 1.0);
    float k = (r * r) / 8.0;
    float nom = NdotV;
    float denom = NdotV * (1.0 - k) + k;
    return nom / denom;
}

float GeometrySmith(vec3 N, vec3 V, vec3 L, float k)
{
    float NdotV = max(dot(N, V), 0.0);
    float NdotL = max(dot(N, L), 0.0);
    float ggx1 = GeometrySchlickGGX(NdotV, k);
    float ggx2 = GeometrySchlickGGX(NdotL, k);
    return ggx1 * ggx2;
}

//菲涅貳函數,F0为金属反射率
vec3 fresnelSchlick(float cosTheta, vec3 F0)
{
    return F0 + (1.0 - F0) * pow(1.0 - cosTheta, 5.0);
}

vec3 fresnelSchlickRoughness(float cosTheta, vec3 F0, float roughness)
{
    return F0 + (max(vec3(1.0 - roughness), F0) - F0) * pow(1.0 - cosTheta, 5.0);
}   


//求法线贴图的法线向量
vec3 getNormalFromMap()
{
    vec3 tangentNormal = texture(normalMap, TexCoords).xyz * 2.0 - 1.0;
    vec3 Q1 = dFdx(WorldPos);
    vec3 Q2 = dFdy(WorldPos);
    vec2 st1 = dFdx(TexCoords);
    vec2 st2 = dFdy(TexCoords);
    
    vec3 N = normalize(WorldNormal);
    vec3 T = normalize(Q1 * st2.t - Q2 * st1.t);
    vec3 B = -normalize(cross(N, T));
    mat3 TBN = mat3(T, B, N);
    
    return normalize(TBN * tangentNormal);
}


void main()
{
    vec3 N = getNormalFromMap();
    vec3 albedo = pow(texture(albedoMap, TexCoords).xyz, vec3(2.2));
    float roughness = texture(roughnessMap, TexCoords).x;
    float metallic = texture(metallicMap, TexCoords).x;
    float ao = texture(aoMap, TexCoords).x;
    
    vec3 V = normalize(cameraPos - WorldPos);
    vec3 R = reflect(-V, N);
    
    vec3 F0 = vec3(0.04);
    F0 = mix(F0, albedo, metallic);
    
    
    //反射方程式
    vec3 Lo = vec3(0.0);
    for(int i = 0; i < 4; ++i)
    {
        vec3 L = normalize(lightPositions[i] - WorldPos);
        vec3 H = normalize(V + L);
        float distance = length(lightPositions[i] - WorldPos);
        float atten = 1.0 / (distance * distance);
        vec3 radiance = lightColors[i] * atten;
        
        //Cook-Torrance BRDF
        float NDF = DistributionGGX(N, H, roughness);
        float G = GeometrySmith(N, V, L, roughness);
        vec3 F = fresnelSchlick(max(dot(H, V), 0.0), F0);
        vec3 nomiator = NDF * G * F;
        float denominator = 4 * max(dot(N, V), 0.0) * max(dot(N, L), 0.0) + 0.001;
        vec3 specular = nomiator / denominator;
        
        //Ks
        vec3 Ks = F;
        vec3 Kd = vec3(1.0) - Ks;
        
        //Kd
        Kd *= 1.0 - metallic;
        
        float NdotL = max(dot(N, L), 0.0);
        
        Lo += (Kd * albedo / PI + specular) * radiance * NdotL;
    }
    
    vec3 F = fresnelSchlickRoughness(max(dot(N, V), 0.0), F0, roughness);
    vec3 Ks = F;
    vec3 Kd = 1.0 - Ks;
    Kd *= 1.0 - metallic;
    vec3 irradiance = texture(irradianceMap, N).rgb;
    vec3 diffuse = irradiance * albedo;
    
    const float MAX_REFLECTION_LOD = 4.0;
    vec3 prefilteredColor	= textureLod(preflitterMap, R, roughness * MAX_REFLECTION_LOD).rgb;
    vec2 brdf = texture(brdfLUT, vec2(max(dot(N, V), 0.0), roughness)).rg;
    vec3 specular = prefilteredColor * (F * brdf.x + brdf.y);
    
    vec3 ambient = (Kd * diffuse + specular)*ao;
    vec3 color = ambient + Lo;
    
    //toneMAP
    color = color / (color+vec3(1.0));
    
    //gammaCorrect
    color = pow(color, vec3(1.0 / 2.2));
    
    fColor = vec4(color, 1.0f);
}
";

    }
}
