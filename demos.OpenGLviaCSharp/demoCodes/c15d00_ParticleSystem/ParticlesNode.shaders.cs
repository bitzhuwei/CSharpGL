using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d00_ParticleSystem {
    partial class ParticlesNode {
        private const string computeCode = @"#version 430 core

// position and mass of atractors.
uniform vec4 attractors[64]; // xyz = position, w = mass
// 128 particles for each part.
layout (local_size_x = 128) in;
// velocities of partiles.
layout (rgba32f, binding = 0) uniform imageBuffer positionBuffer;
// masses of partiles.
layout (rgba32f, binding = 1) uniform imageBuffer velocityBuffer;
// time interval.
uniform vec3 gravity = vec3(0, -9.81, 0);
uniform float deltaTime; // in seconds.
uniform float dieSpeed = 0.02;


// return value between [-1, 1].
float rand(float seed){
    return fract(sin(dot(vec2(seed, seed * seed), vec2(345.0324, 51.8234))) * 9846.29384) - 0.5;
}

void main(void)
{
    int id = int(gl_GlobalInvocationID.x);
    // read position and velocity of current particle.
    vec4 pos = imageLoad(positionBuffer, id);
    vec4 vel = imageLoad(velocityBuffer, id);

    pos.xyz += deltaTime * vel.xyz;
    pos.w -= deltaTime;
    vel.xyz += gravity * deltaTime;

    if (pos.w < 0)
	{
        pos.w = 6;
		vel.xyz = vec3(rand(id * 3 + deltaTime + 0) * 8, rand(id * 3 + deltaTime + 1) * 8, rand(id * 3 + deltaTime + 2) * 8);
		pos.xyz = vec3(0, 5, 0) - vec3(rand(id * 3 + 0) * 4, rand(id * 3 + 1) * 2, rand(id * 3 + 2) * 4);
	}

    if (pos.y < -3) {
        vel.xyz = reflect(vel.xyz, vec3(0, 1, 0)) * 0.8;
        pos.y = -3;
    }

    // write positon and velocity to buffer.
    imageStore(positionBuffer, id, pos);
    imageStore(velocityBuffer, id, vel);
}
";

        private const string renderVert = @"
#version 330

in vec4 inPosition;

out float life;

void main() {
    gl_Position = vec4(inPosition.xyz, 1.0);
    life = inPosition.w;
}
";
        private const string renderGeom =
         @"#version 330
layout (points) in;
layout (triangle_strip, max_vertices = 4) out;

uniform mat4 projectionMat;
uniform mat4 viewMat;

in float life[];

out vec2 texCoord;
out float passLife;

void main() {
    passLife = life[0];

    vec4 pos = viewMat * gl_in[0].gl_Position;
    texCoord = vec2(-1, -1);
    gl_Position = projectionMat * (pos + 0.2 * vec4(texCoord, 0, 0));
    EmitVertex();
    texCoord = vec2( 1, -1);
    gl_Position = projectionMat * (pos + 0.2 * vec4(texCoord, 0, 0));
    EmitVertex();
    texCoord = vec2(-1,  1);
    gl_Position = projectionMat * (pos + 0.2 * vec4(texCoord, 0, 0));
    EmitVertex();
    texCoord = vec2( 1,  1);
    gl_Position = projectionMat * (pos + 0.2 * vec4(texCoord, 0, 0));
    EmitVertex();

    EndPrimitive();
}
";
        private const string renderFrag =
         @"#version 330

in vec2 texCoord;
in float passLife;

out vec4 outColor;

uniform vec4 color1 = vec4(0.3, 0.7, 0.1, 0.4);
uniform vec4 color2 = vec4(0.8, 0.2, 0.9, 0.1);

void main() {
    float distance = dot(texCoord, texCoord);
    if (distance > 0.5) discard;
    vec4 color = color1 * distance + color2 * (1.0 - distance);
    color.a *= (passLife / 6);
    outColor = color;
} 
";
    }
}
