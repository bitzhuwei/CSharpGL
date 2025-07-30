#version 420 core

layout (binding = 0) uniform sampler2D tex_object;

in VS_OUT
{
    vec2 tc;
} fs_in;

out vec4 color;

void main(void)
{
    color = texture(tex_object, fs_in.tc * vec2(3.0, 1.0));
}
