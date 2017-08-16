using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace BasicTessellationShader
{
    public partial class BasicTessellationNode
    {
        private const string renderVert = @"#version 410 core                                                                               
                                                                                                
layout (location = 0) in vec3 Position_VS_in;                                                   
layout (location = 1) in vec2 TexCoord_VS_in;                                                   
layout (location = 2) in vec3 Normal_VS_in;                                                     
                                                                                                
uniform mat4 gWorld;                                                                            
                                                                                                
out vec3 WorldPos_CS_in;                                                                        
out vec2 TexCoord_CS_in;                                                                        
out vec3 Normal_CS_in;                                                                          
                                                                                                
void main()                                                                                     
{                                                                                               
    WorldPos_CS_in = (gWorld * vec4(Position_VS_in, 1.0)).xyz;                                  
    TexCoord_CS_in = TexCoord_VS_in;                                                            
    Normal_CS_in   = (gWorld * vec4(Normal_VS_in, 0.0)).xyz;                                    
}
";
        private const string renderTesc = @"#version 410 core                                                                               
                                                                                                
// define the number of CPs in the output patch                                                 
layout (vertices = 3) out;                                                                      
                                                                                                
uniform vec3 gEyeWorldPos;                                                                      
                                                                                                
// attributes of the input CPs                                                                  
in vec3 WorldPos_CS_in[];                                                                       
in vec2 TexCoord_CS_in[];                                                                       
in vec3 Normal_CS_in[];                                                                         
                                                                                                
// attributes of the output CPs                                                                 
out vec3 WorldPos_ES_in[];                                                                      
out vec2 TexCoord_ES_in[];                                                                      
out vec3 Normal_ES_in[];                                                                        
                                                                                                
float GetTessLevel(float Distance0, float Distance1)                                            
{                                                                                               
    float AvgDistance = (Distance0 + Distance1) / 2.0;                                          
                                                                                                
    if (AvgDistance <= 2.0) {                                                                   
        return 10.0;                                                                            
    }                                                                                           
    else if (AvgDistance <= 5.0) {                                                              
        return 7.0;                                                                             
    }                                                                                           
    else {                                                                                      
        return 3.0;                                                                             
    }                                                                                           
}                                                                                               
                                                                                                
void main()                                                                                     
{                                                                                               
    // Set the control points of the output patch                                               
    TexCoord_ES_in[gl_InvocationID] = TexCoord_CS_in[gl_InvocationID];                          
    Normal_ES_in[gl_InvocationID]   = Normal_CS_in[gl_InvocationID];                            
    WorldPos_ES_in[gl_InvocationID] = WorldPos_CS_in[gl_InvocationID];                          
                                                                                                
    // Calculate the distance from the camera to the three control points                       
    float EyeToVertexDistance0 = distance(gEyeWorldPos, WorldPos_ES_in[0]);                     
    float EyeToVertexDistance1 = distance(gEyeWorldPos, WorldPos_ES_in[1]);                     
    float EyeToVertexDistance2 = distance(gEyeWorldPos, WorldPos_ES_in[2]);                     
                                                                                                
    // Calculate the tessellation levels                                                        
    gl_TessLevelOuter[0] = GetTessLevel(EyeToVertexDistance1, EyeToVertexDistance2);            
    gl_TessLevelOuter[1] = GetTessLevel(EyeToVertexDistance2, EyeToVertexDistance0);            
    gl_TessLevelOuter[2] = GetTessLevel(EyeToVertexDistance0, EyeToVertexDistance1);            
    gl_TessLevelInner[0] = gl_TessLevelOuter[2];                                                
}                                                                                               
";
        private const string renderTese = @"#version 410 core                                                                               
                                                                                                
layout(triangles, equal_spacing, ccw) in;                                                       
                                                                                                
uniform mat4 gVP;                                                                               
uniform sampler2D gDisplacementMap;                                                             
uniform float gDispFactor;                                                                      
                                                                                                
in vec3 WorldPos_ES_in[];                                                                       
in vec2 TexCoord_ES_in[];                                                                       
in vec3 Normal_ES_in[];                                                                         
                                                                                                
out vec3 WorldPos_FS_in;                                                                        
out vec2 TexCoord_FS_in;                                                                        
out vec3 Normal_FS_in;                                                                          
                                                                                                
vec2 interpolate2D(vec2 v0, vec2 v1, vec2 v2)                                                   
{                                                                                               
    return vec2(gl_TessCoord.x) * v0 + vec2(gl_TessCoord.y) * v1 + vec2(gl_TessCoord.z) * v2;   
}                                                                                               
                                                                                                
vec3 interpolate3D(vec3 v0, vec3 v1, vec3 v2)                                                   
{                                                                                               
    return vec3(gl_TessCoord.x) * v0 + vec3(gl_TessCoord.y) * v1 + vec3(gl_TessCoord.z) * v2;   
}                                                                                               
                                                                                                
void main()                                                                                     
{                                                                                               
    // Interpolate the attributes of the output vertex using the barycentric coordinates        
    TexCoord_FS_in = interpolate2D(TexCoord_ES_in[0], TexCoord_ES_in[1], TexCoord_ES_in[2]);    
    Normal_FS_in = interpolate3D(Normal_ES_in[0], Normal_ES_in[1], Normal_ES_in[2]);            
    Normal_FS_in = normalize(Normal_FS_in);                                                     
    WorldPos_FS_in = interpolate3D(WorldPos_ES_in[0], WorldPos_ES_in[1], WorldPos_ES_in[2]);    
                                                                                                
    // Displace the vertex along the normal                                                     
    float Displacement = texture(gDisplacementMap, TexCoord_FS_in.xy).x;                        
    WorldPos_FS_in += Normal_FS_in * Displacement * gDispFactor;                                
    gl_Position = gVP * vec4(WorldPos_FS_in, 1.0);                                              
}                                                                                               
";
        private const string renderFrag = @"#version 410 core                                                                           
                                                                                            
const int MAX_POINT_LIGHTS = 2;                                                             
const int MAX_SPOT_LIGHTS = 2;                                                              
                                                                                            
in vec2 TexCoord_FS_in;                                                                     
in vec3 Normal_FS_in;                                                                       
in vec3 WorldPos_FS_in;                                                                     
                                                                                            
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
                                                                                            
struct Attenuation                                                                          
{                                                                                           
    float Constant;                                                                         
    float Linear;                                                                           
    float Exp;                                                                              
};                                                                                          
                                                                                            
struct PointLight                                                                           
{                                                                                           
    BaseLight Base;                                                                  
    vec3 Position;                                                                          
    Attenuation Atten;                                                                      
};                                                                                          
                                                                                            
struct SpotLight                                                                            
{                                                         
            else if (rendererType == typeof(ZeroAttributeRenderer))
            {
                renderer = ZeroAttributeRenderer.Create();
                                              
    PointLight Base;                                                                 
    vec3 Direction;                                                                         
    float Cutoff;                                                                           
};                                                                                          
                                                                                            
uniform int gNumPointLights;                                                                
uniform int gNumSpotLights;                                                                 
uniform DirectionalLight gDirectionalLight;                                                 
uniform PointLight gPointLights[MAX_POINT_LIGHTS];                                          
uniform SpotLight gSpotLights[MAX_SPOT_LIGHTS];                                             
uniform sampler2D gColorMap;                                                                
uniform vec3 gEyeWorldPos;                                                                  
uniform float gMatSpecularIntensity;                                                        
uniform float gSpecularPower;                                                               
                                                                                            
vec4 CalcLightInternal(BaseLight Light, vec3 LightDirection, vec3 Normal)            
{                                                                                           
    vec4 AmbientColor = vec4(Light.Color * Light.AmbientIntensity, 1.0f);
    float DiffuseFactor = dot(Normal, -LightDirection);                                     
                                                                                            
    vec4 DiffuseColor  = vec4(0, 0, 0, 0);                                                  
    vec4 SpecularColor = vec4(0, 0, 0, 0);                                                  
                                                                                            
    if (DiffuseFactor > 0) {                                                                
        DiffuseColor = vec4(Light.Color * Light.DiffuseIntensity * DiffuseFactor, 1.0f);
                                                                                            
        vec3 VertexToEye = normalize(gEyeWorldPos - WorldPos_FS_in);                        
        vec3 LightReflect = normalize(reflect(LightDirection, Normal));                     
        float SpecularFactor = dot(VertexToEye, LightReflect);                              
        if (SpecularFactor > 0) {                                                           
            SpecularFactor = pow(SpecularFactor, gSpecularPower);                               
            SpecularColor = vec4(Light.Color * gMatSpecularIntensity * SpecularFactor, 1.0f);
        }                                                                                   
    }                                                                                       
                                                                                            
    return (AmbientColor + DiffuseColor + SpecularColor);                                   
}                                                                                           
                                                                                            
vec4 CalcDirectionalLight(vec3 Normal)                                                      
{                                                                                           
    return CalcLightInternal(gDirectionalLight.Base, gDirectionalLight.Direction, Normal);  
}                                                                                           
                                                                                            
vec4 CalcPointLight(PointLight l, vec3 Normal)                                       
{                                                                                           
    vec3 LightDirection = WorldPos_FS_in - l.Position;                                      
    float Distance = length(LightDirection);                                                
    LightDirection = normalize(LightDirection);                                             
                                                                                            
    vec4 Color = CalcLightInternal(l.Base, LightDirection, Normal);                         
    float Attenuation =  l.Atten.Constant +                                                 
                         l.Atten.Linear * Distance +                                        
                         l.Atten.Exp * Distance * Distance;                                 
                                                                                            
    return Color / Attenuation;                                                             
}                                                                                           
                                                                                            
vec4 CalcSpotLight(SpotLight l, vec3 Normal)                                         
{                                                                                           
    vec3 LightToPixel = normalize(WorldPos_FS_in - l.Base.Position);                        
    float SpotFactor = dot(LightToPixel, l.Direction);                                      
                                                                                            
    if (SpotFactor > l.Cutoff) {                                                            
        vec4 Color = CalcPointLight(l.Base, Normal);                                        
        return Color * (1.0 - (1.0 - SpotFactor) * 1.0/(1.0 - l.Cutoff));                   
    }                                                                                       
    else {                                                                                  
        return vec4(0,0,0,0);                                                               
    }                                                                                       
}                                                                                           
                                                                                            
void main()                                                                                 
{                                                                                           
    vec3 Normal = normalize(Normal_FS_in);                                                  
    vec4 TotalLight = CalcDirectionalLight(Normal);                                         
                                                                                            
    for (int i = 0 ; i < gNumPointLights ; i++) {                                           
        TotalLight += CalcPointLight(gPointLights[i], Normal);                              
    }                                                                                       
                                                                                            
    for (int i = 0 ; i < gNumSpotLights ; i++) {                                            
        TotalLight += CalcSpotLight(gSpotLights[i], Normal);                                
    }                                                                                       
                                                                                            
    FragColor = texture(gColorMap, TexCoord_FS_in.xy) * TotalLight;                         
}
";
    }
}
