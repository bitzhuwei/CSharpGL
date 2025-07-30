#version 410 core

in vec4 position;
uniform mat4 mvp;

void main(void)
{
    gl_Position = mvp * position;
}
