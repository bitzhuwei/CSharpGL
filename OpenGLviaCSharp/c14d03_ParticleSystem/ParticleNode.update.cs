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
uniform float deltaTime = 0.5f;
uniform float bounce;
uniform int seed;

out vec3 outPosition;
out vec4 outVelocity;

// return value between [-1, 1].
float rand(float seed){
 return fract(sin(dot(vec2(seed, seed * seed), vec2(12.9898,78.233))) * 43758.5453) - 0.5;
}
 
void main() {
    outVelocity = inVelocity;

    bool collision = false;
	for(int j = 0;j < 0; ++j) {
        vec3 diff = inPosition - center[j];
		float dist = length(diff);
		float vdot = dot(diff, inVelocity.xyz);
		if(dist < radius[j] && vdot < 0.0) {
		    outVelocity.xyz -= bounce * diff * vdot / (dist * dist);
			outPosition = normalize(diff) * (0.2 + radius[j]) + center[j];
			collision = true;
		}
	}
	if (!collision) {
	    outVelocity.xyz += deltaTime * gravity;
		outPosition = inPosition + deltaTime * outVelocity.xyz;
	}
	
    outVelocity.w = inVelocity.w - 1 * deltaTime;

    if (outVelocity.w < 0)
	{
        outVelocity.w = 6;
		outVelocity.xyz = vec3(rand(gl_VertexID * 3 + deltaTime + 0) * 8, rand(gl_VertexID * 3 + deltaTime + 1), rand(gl_VertexID * 3 + deltaTime + 2) * 8);
		outPosition = vec3(0, 5, 0) - vec3(rand(gl_VertexID * 3 + 0) * 4, rand(gl_VertexID * 3 + 1) * 2, rand(gl_VertexID * 3 + 2) * 4);
	}

    if (outPosition.y < -3) {
        outVelocity.xyz = reflect(outVelocity.xyz, vec3(0, 1, 0)) * 0.8;
    }
}
";

    }
}
