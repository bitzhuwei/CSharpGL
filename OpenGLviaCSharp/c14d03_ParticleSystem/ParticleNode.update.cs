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

uniform vec3 gravity = vec3(0, -9.81, 0);
uniform float deltaTime; // in seconds.

out vec3 outPosition;
out vec4 outVelocity;

// return value between [-1, 1].
float rand(float seed){
    return fract(sin(dot(vec2(seed, seed * seed), vec2(345.0324, 51.8234))) * 9846.29384) - 0.5;
}
 
void main() {
	outPosition = inPosition + deltaTime * inVelocity.xyz;
	outVelocity.xyz = inVelocity.xyz + deltaTime * gravity;		
	outVelocity.w = inVelocity.w - 1 * deltaTime;

    if (outVelocity.w < 0)
	{
        outVelocity.w = 6;
		outVelocity.xyz = vec3(rand(gl_VertexID * 3 + deltaTime + 0) * 8, rand(gl_VertexID * 3 + deltaTime + 1), rand(gl_VertexID * 3 + deltaTime + 2) * 8);
		outPosition = vec3(0, 5, 0) - vec3(rand(gl_VertexID * 3 + 0) * 4, rand(gl_VertexID * 3 + 1) * 2, rand(gl_VertexID * 3 + 2) * 4);
	}

    if (outPosition.y < -3) {
        outVelocity.xyz = reflect(outVelocity.xyz, vec3(0, 1, 0)) * 0.8;
        outPosition.y = -3;
    }
}
";

    }
}
