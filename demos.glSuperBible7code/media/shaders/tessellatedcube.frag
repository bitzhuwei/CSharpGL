#version 420 core

out vec4 color;

in vec3 normal;

void main(void)
{
    color = vec4(abs(normal), 1.0);
}