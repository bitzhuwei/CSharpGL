#version 420 core

uniform sampler2D tex;

out vec4 color;

in VS_OUT
{
    vec4 color;
    vec2 texcoord;
} fs_in;

void main(void)
{
    color = mix(fs_in.color, texture(tex, fs_in.texcoord), 0.7);
}