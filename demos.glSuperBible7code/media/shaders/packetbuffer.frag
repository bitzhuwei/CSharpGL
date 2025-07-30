#version 440 core
layout (location = 0) out vec4 color;
in vec4 vs_fs_color;
void main(void)
{
    color = vs_fs_color;
}