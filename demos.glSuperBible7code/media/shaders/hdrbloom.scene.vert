#version 420 core

layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;

out VS_OUT
{
    vec3 N;
    vec3 L;
    vec3 V;
    flat int material_index;
} vs_out;

// Position of light
uniform vec3 light_pos = vec3(100.0, 100.0, 100.0);

layout (binding = 0, std140) uniform TRANSFORM_BLOCK
{
    mat4    mat_proj;
    mat4    mat_view;
    mat4    mat_model[32];
} transforms;

void main(void)
{
    mat4    mat_mv = transforms.mat_view * transforms.mat_model[gl_InstanceID];

    // Calculate view-space coordinate
    vec4 P = mat_mv * position;

    // Calculate normal in view-space
    vs_out.N = mat3(mat_mv) * normal;

    // Calculate light vector
    vs_out.L = light_pos - P.xyz;

    // Calculate view vector
    vs_out.V = -P.xyz;

    // Pass material index
    vs_out.material_index = gl_InstanceID;

    // Calculate the clip-space position of each vertex
    gl_Position = transforms.mat_proj * P;
}
