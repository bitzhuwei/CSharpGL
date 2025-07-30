#version 420 core

uniform mat4 mv_matrix;
uniform mat4 proj_matrix;

layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;
layout (location = 4) in vec2 tc;

out VS_OUT
{
    vec3 normal;
    vec3 view;
    vec2 tc;
} vs_out;

void main(void)
{
    vec4 pos_vs = mv_matrix * position;

    vs_out.normal = mat3(mv_matrix) * normal;
    vs_out.view = pos_vs.xyz;
    vs_out.tc = tc;

    gl_Position = proj_matrix * pos_vs;
}
