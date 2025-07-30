#version 430 core

in vec4 vert;

uniform mat4 mvp;

out float intensity;

void main(void)
{
    intensity = vert.w;
    gl_Position = mvp * vec4(vert.xyz, 1.0);
}