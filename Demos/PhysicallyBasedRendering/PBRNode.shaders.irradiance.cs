using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    partial class PBRNode
    {
        private const string irradianceVertexCode = @"#version 330 core
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

        private const string irradianceFragmentCode = @"#version 330 core

in vec3 WorldPos;

uniform samplerCube environmentMap;

const float PI=3.14159265359;


out vec4 fColor;
void main()
{
   vec3 N=normalize(WorldPos);

   vec3 irrandiance=vec3(0.0);

   vec3 up=vec3(0.0,1.0,0.0);

   vec3 right=cross(up,N);
   up=cross(N,right);

   float sampleDelta=0.025;
   float nrSamples=0.0;

   for(float phi=0.0;phi<2.0*PI;phi+=sampleDelta)
   {
      for(float theta=0.0;theta<0.5*PI;theta+=sampleDelta)
	  {
	   vec3 tangentSample=vec3(sin(theta)*cos(phi),sin(theta)*sin(phi),cos(theta));
	   vec3 sampleVec=tangentSample.x*right+tangentSample.y*up+tangentSample.z*N;
	   irrandiance+=texture(environmentMap,sampleVec).rgb*cos(theta)*sin(theta);
	   nrSamples++;
	  }
   }

   irrandiance=PI*irrandiance*(1.0/float(nrSamples));
} 
";

    }
}
