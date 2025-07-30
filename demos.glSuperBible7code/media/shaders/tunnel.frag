#version 420 core

layout (location = 0) out vec4 color;

in VS_OUT
{
    vec2 tc;
} fs_in;

layout (binding = 0) uniform sampler2D tex;

void main(void)
{
    color = texture(tex, fs_in.tc);
}