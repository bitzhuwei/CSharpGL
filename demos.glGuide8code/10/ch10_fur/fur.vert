#version 410

layout (location = 0) in vec4 position_in;
layout (location = 1) in vec3 normal_in;
layout (location = 2) in vec2 texcoord_in;

out VS_GS_VERTEX
{
    vec3 normal;
    vec2 tex_coord;
} vertex_out;

void main(void)
{
    vertex_out.normal = normal_in;
    vertex_out.tex_coord = texcoord_in;
    gl_Position = position_in;
}