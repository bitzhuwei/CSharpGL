using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    partial class PBRNode
    {
        private const string equiRectangularVertexCode = @"#version 330 core
layout(location = 0) in vec3 vPosition;

out vec3 WorldPos;
uniform mat4 ViewMatrix;
uniform mat4 ProjMatrix;

void main()
{
    WorldPos=vPosition;
    gl_Position = ProjMatrix*ViewMatrix*vec4(vPosition,1.0f);
}
";

        private const string equiRectangularFragmentCode = @"#version 330 core


in vec3 WorldPos;
uniform sampler2D equirectangularMap;
out vec4 fColor;	


const vec2 invAtan=vec2(0.1591,0.3183);

vec2 SampleSphericalMap(vec3 v)
{
  vec2 uv=vec2(atan(v.z,v.x),asin(v.y));
  uv*=invAtan;
  uv+=0.5;
  return uv;
}


void main()
{
    vec2 uv=SampleSphericalMap(normalize(WorldPos));
    vec3 color=texture(equirectangularMap,uv).rgb;
     fColor =vec4(color,1.0f);
} 
";

    }
}
