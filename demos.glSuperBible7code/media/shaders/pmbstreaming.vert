#version 440 core

#extension GL_ARB_shader_draw_parameters : require

// Per-vertex inputs
layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;
layout (location = 4) in vec2 tc;

struct MATRICES
{
    mat4 modelview;
    mat4 projection;
};

// Matrices we'll need
layout (std140) uniform constants
{
    MATRICES matrices[16];
};

// Inputs from vertex shader
out VS_OUT
{
    vec3 N;
    vec3 L;
    vec3 V;
    vec2 tc;
} vs_out;

// Position of light
const vec3 light_pos = vec3(100.0, 100.0, 100.0);

void main(void)
{
    mat4 mv_matrix = matrices[gl_BaseInstanceARB].modelview;
    mat4 proj_matrix = matrices[gl_BaseInstanceARB].projection;

    // Calculate view-space coordinate
    vec4 P = mv_matrix * position;

    // Calculate normal in view-space
    vs_out.N = mat3(mv_matrix) * normal;

    // Calculate light vector
    vs_out.L = light_pos - P.xyz;

    // Calculate view vector
    vs_out.V = -P.xyz;

    // Pass texture coordinate through
    vs_out.tc = tc * vec2(5.0, 1.0);

    // Calculate the clip-space position of each vertex
    gl_Position = proj_matrix * P;
}
