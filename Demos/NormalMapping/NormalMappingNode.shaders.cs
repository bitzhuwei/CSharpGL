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
    gl_Position   = mvpMat * vec4(inPosition, 1.0);                                     
    passWorldPos  = (modelMat * vec4(inPosition, 1.0)).xyz;                             
    passNormal    = (modelMat * vec4(inNormal, 0.0)).xyz;                               
    passTangent   = (modelMat * vec4(inTangent, 0.0)).xyz;                              
    passTexCoord  = inTexCoord;                                                       
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
                                                                                            
vec4 CalcLightInternal(BaseLight Light, vec3 LightDirection, vec3 Normal,                   
                       float ShadowFactor)                                                  
{                                                                                           
    vec4 AmbientColor = vec4(Light.Color * Light.AmbientIntensity, 1.0f);
    float DiffuseFactor = dot(Normal, -LightDirection);                                     
                                                                                            
    vec4 DiffuseColor  = vec4(0, 0, 0, 0);                                                  
    vec4 SpecularColor = vec4(0, 0, 0, 0);                                                  
                                                                                            
    if (DiffuseFactor > 0) {                                                                
        DiffuseColor = vec4(Light.Color * Light.DiffuseIntensity * DiffuseFactor, 1.0f);
                                                                                            
        vec3 VertexToEye = normalize(gEyeWorldPos - passWorldPos);                             
        vec3 LightReflect = normalize(reflect(LightDirection, Normal));                     
        float SpecularFactor = dot(VertexToEye, LightReflect);                                      
        if (SpecularFactor > 0) {                                                           
            SpecularFactor = pow(SpecularFactor, gSpecularPower);                               
            SpecularColor = vec4(Light.Color * gMatSpecularIntensity * SpecularFactor, 1.0f);
        }                                                                                   
    }                                                                                       
                                                                                            
    return (AmbientColor + ShadowFactor * (DiffuseColor + SpecularColor));                  
}                                                                                           
                                                                                            
vec4 CalcDirectionalLight(vec3 Normal)                                                      
{                                                                                                
    return CalcLightInternal(gDirectionalLight.Base, gDirectionalLight.Direction, Normal, 1.0);  
}                                                                                                
                                                                                            
vec3 CalcBumpedNormal()                                                                     
{                                                                                           
    vec3 Normal = normalize(passNormal);                                                       
    vec3 Tangent = normalize(passTangent);                                                     
    Tangent = normalize(Tangent - dot(Tangent, Normal) * Normal);                           
    vec3 Bitangent = cross(Tangent, Normal);                                                
    vec3 BumpMapNormal = texture(gNormalMap, passTexCoord).xyz;                                
    BumpMapNormal = 2.0 * BumpMapNormal - vec3(1.0, 1.0, 1.0);                              
    vec3 NewNormal;                                                                         
    mat3 TBN = mat3(Tangent, Bitangent, Normal);                                            
    NewNormal = TBN * BumpMapNormal;                                                        
    NewNormal = normalize(NewNormal);                                                       
    return NewNormal;                                                                       
}                                                                                           
                                                                                            
void main()                                                                                 
{                                                                                           
    vec3 Normal = CalcBumpedNormal();                                                       
    vec4 TotalLight = CalcDirectionalLight(Normal);                                         
                                                                                            
    vec4 SampledColor = texture2D(gColorMap, passTexCoord.xy);                                 
    FragColor = SampledColor * TotalLight;                                                  
}
";
    }
}
