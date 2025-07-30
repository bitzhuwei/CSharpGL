#version 440 core

#extension GL_ARB_shader_draw_parameters : require

// Per-vertex inputs
layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;
layout (location = 4) in vec2 tc;

// Matrices we'll need
layout (std140, binding = 0) uniform MATRIX_BLOCK
{
#if 0
    mat4 view_matrix;
    mat4 proj_matrix;
    mat4 model_matrix[384];
#else
    mat4 model_matrix[386];
#endif
};

// 

// Inputs from vertex shader
out VS_OUT
{
    vec3 N;
    vec3 L;
    vec3 V;
    vec2 tc;
    flat uint instance_index;
} vs_out;

// Position of light
const vec3 light_pos = vec3(100.0, 100.0, 100.0);

void main(void)
{
#if 1
    mat4 view_matrix = model_matrix[0];
    mat4 proj_matrix = model_matrix[1];
#endif

    mat4 mv_matrix = view_matrix * model_matrix[gl_InstanceID + 2];
    // mat4 proj_matrix = proj_matrix;

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

    // Pass instance ID through
    vs_out.instance_index = gl_InstanceID;

    // Calculate the clip-space position of each vertex
    gl_Position = proj_matrix * P;
}
