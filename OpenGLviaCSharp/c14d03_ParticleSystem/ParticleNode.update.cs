using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c14d03_ParticleSystem
{
    partial class ParticleNode
    {
        private const string updateVert =
         @"#version 330
in vec3 inPosition;
in vec4 inVelocity;

uniform vec3 center[3];
uniform float radius[3];
uniform vec3 gravity;
uniform float deltaTime;
uniform float bounce;
uniform int seed;

out vec3 outPosition;
out vec4 outVelocity;

float hash(int x) {
   x = x * 1235167 + gl_VertexID * 948737 + seed * 9284365;
   x = (x >> 13) ^ x;
   return ((x * (x * x * 60493 + 19990303) + 1376312589) & 0x7fffffff) / float(0x7fffffff - 1);
}

float rand(float seed){
    return fract(sin(seed * 12.9898)) * 43758.5453;
}

void main() {
   outVelocity = inVelocity;
   for(int j = 0;j < 3; ++j) {
       vec3 diff = inPosition - center[j];
       float dist = length(diff);
       float vdot = dot(diff, inVelocity.xyz);
       if(dist < radius[j] && vdot < 0.0)
           outVelocity.xyz -= bounce * diff * vdot / (dist * dist);
   }
   outVelocity.xyz += deltaTime * gravity;
   outPosition = inPosition + deltaTime * outVelocity.xyz;
   if(outPosition.y < -5.0)
   {
       outVelocity.xyz = vec3(0, hash(gl_VertexID), 0);
       outPosition = 0.5 - vec3(hash(3 * gl_VertexID + 0), hash(3 * gl_VertexID + 1), hash(3 * gl_VertexID + 2));
       outPosition = vec3(0, 5, 0) + 5.0 * outPosition;
   }
}
";
    }
}
