#version 440 core
layout (location = 0) out vec4 o_color;
in vec4 particle_color;
void main(void)
{
    o_color = particle_color;
}