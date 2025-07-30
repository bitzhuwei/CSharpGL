#version 430 core

in vec4 vert;

void main(void)
{
    gl_Position = vec4(vert.x * 0.8f, vert.y * 0.8f, vert.zw);
}