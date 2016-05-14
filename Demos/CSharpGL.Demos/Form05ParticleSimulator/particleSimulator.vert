#version 430 core

in vec4 position;

uniform mat4 mvp;

out float intensity;

void main(void)
{
    intensity = position.w;
    gl_Position = mvp * vec4(position.xyz, 1.0);
}