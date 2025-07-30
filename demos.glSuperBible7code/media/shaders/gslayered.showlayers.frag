#version 420 core

layout (binding = 0) uniform sampler2DArray tex_array;

layout (location = 0) out vec4 color;

in VS_OUT
{
    vec3 tc;
} fs_in;

void main(void)
{
    color = texture(tex_array, fs_in.tc);
}

