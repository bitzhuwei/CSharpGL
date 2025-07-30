#version 420 core

layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;

out VS_OUT
{
    vec4 color;
    vec3 normal;
} vs_out;

void main(void)
{
    gl_Position = position;
    vs_out.normal = normal;
}
