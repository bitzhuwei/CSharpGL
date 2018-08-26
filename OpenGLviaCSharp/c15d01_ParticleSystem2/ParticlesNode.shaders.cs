using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d01_ParticleSystem2
{
    partial class ParticlesNode
    {
        private const string computeCode = @"#version 430 core

// position and mass of atractors.
uniform vec4 attractors[64]; // xyz = position, w = mass

// 128 particles for each part.
layout (local_size_x = 128) in;

// position(xyz) and life(w) of partiles.
layout (rgba32f, binding = 0) uniform imageBuffer positionBuffer;
// velocity of partiles.
layout (rgba32f, binding = 1) uniform imageBuffer velocityBuffer;

// time interval.
uniform float deltaTime; // in seconds.


// return value between [-1, 1].
float rand(float seed){
    return fract(sin(dot(vec2(seed, seed * seed), vec2(345.0324, 51.8234))) * 9846.29384) - 0.5;
}

void main(void)
{
    int id = int(gl_GlobalInvocationID.x);
    // read position and velocity of current particle.
    vec4 position = imageLoad(positionBuffer, id);
    vec4 velocity = imageLoad(velocityBuffer, id);

    int i;
    // update position and life.
    position.xyz += velocity.xyz * deltaTime;
    position.w -= 0.1 * deltaTime;
    // for each attractorss.
    for (i = 0; i < 64; i++)
    {
        // update velocity according to force.
        vec3 dist = (attractors[i].xyz - position.xyz);
        velocity.xyz += deltaTime * deltaTime * attractors[i].w * normalize(dist) / (dot(dist, dist) + 0.1);
    }
    // reset particle if it's dead.
    if (position.w <= 0.0)
    {
        position.w = 6;
        position.xyz = vec3(0);
        velocity.xyz *= 0.01;
    }
    // write positon and velocity to buffer.
    imageStore(positionBuffer, id, position);
    imageStore(velocityBuffer, id, velocity);
}
";

        private const string vertexCode = @"#version 430 core

in vec4 inPosition;

uniform mat4 mvp;

out float intensity;

void main(void)
{
    intensity = inPosition.w;// life cycle (0 - 1).
    gl_Position = mvp * vec4(inPosition.xyz, 1.0);
}
";

        private const string fragmentCode = @"#version 430 core

out vec4 outColor;

in float intensity;

void main(void)
{
    outColor = vec4(0.0f, 0.2f, 1.0f, 1.0f) * intensity + vec4(0.2f, 0.05f, 0.0f, 1.0f) * (1.0f - intensity);
}
";

    }
}
