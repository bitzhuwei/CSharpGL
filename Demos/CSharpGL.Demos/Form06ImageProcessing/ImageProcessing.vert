#version 430 core

in vec4 vert;
uniform mat4 mvp;

void main(void)
{
    gl_Position = mvp * vert;
}
