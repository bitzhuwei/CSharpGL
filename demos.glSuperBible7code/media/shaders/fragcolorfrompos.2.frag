#version 420 core

in vec4 vs_color;
out vec4 color;

void main(void)
{
    color = vs_color;
}