#version 410 core

layout (location = 0, index = 0) out vec4 color0;
layout (location = 0, index = 1) out vec4 color1;

in VS_OUT
{
    vec4 color0;
    vec4 color1;
} fs_in;

void main(void)
{
    color0 = vec4(fs_in.color0.xyz, 1.0);
    color1 = vec4(fs_in.color0.xyz, 1.0);
}