#version 420 core

uniform mat4 mvp;

layout (location = 0) in vec4 position;

void main(void)
{
    gl_Position = mvp * position;
}
