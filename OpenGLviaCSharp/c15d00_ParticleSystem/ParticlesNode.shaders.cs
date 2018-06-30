using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d00_ParticleSystem
{
    partial class ParticlesNode
    {
        private const string computeCode = @"#version 430 core

// position and mass of atractors.
uniform vec4 attractors[64]; // xyz = position, w = mass
// 128 particles for each part.
layout (local_size_x = 128) in;
// velocities of partiles.
layout (rgba32f, binding = 0) uniform imageBuffer velocity_buffer;
// masses of partiles.
layout (rgba32f, binding = 1) uniform imageBuffer position_buffer;
// time interval.
uniform float dt; // in seconds.
uniform float dieSpeed = 0.02;

void main(void)
{
    // read position and velocity of current particle.
    vec4 pos = imageLoad(position_buffer, int(gl_GlobalInvocationID.x));
    vec4 vel = imageLoad(velocity_buffer, int(gl_GlobalInvocationID.x));

    int i;
    // update position and life.
    pos.xyz += vel.xyz * dt;
    pos.w -= dieSpeed * dt;
    // for each attractorss.
    for (i = 0; i < 64; i++)
    {
        // update velocity according to force.
        vec3 dist = (attractors[i].xyz - pos.xyz);
        vel.xyz += dt * dt * attractors[i].w * normalize(dist) / (dot(dist, dist) + 0.1);
    }
    // reset particle if it's dead.
    if (pos.w <= 0.0)
    {
        pos.xyz = -pos.xyz * 0.01;
        vel.xyz *= 0.01;
        pos.w += 1.0f;
        pos = vec4(0, 0, 0, 1);
    }
    // write positon and velocity to buffer.
    imageStore(position_buffer, int(gl_GlobalInvocationID.x), pos);
    imageStore(velocity_buffer, int(gl_GlobalInvocationID.x), vel);
}
";

        private const string vertexCode = @"#version 430 core

in vec4 position;

uniform mat4 mvp;

out float intensity;

void main(void)
{
    intensity = position.w;// life cycle (0 - 1).
    gl_Position = mvp * vec4(position.xyz, 1.0);
}
";

        private const string fragmentCode = @"#version 430 core

out vec4 color;

in float intensity;

void main(void)
{
    color = vec4(0.0f, 0.2f, 1.0f, 1.0f) * intensity + vec4(0.2f, 0.05f, 0.0f, 1.0f) * (1.0f - intensity);
}
";

    }
}
