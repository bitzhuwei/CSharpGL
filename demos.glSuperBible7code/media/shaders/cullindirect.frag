#version 440 core

layout (location = 0) out vec4 o_color;

layout (binding = 0) uniform sampler2D tex;

in VS_FS
{
    vec2    tc;
    vec3    normal;
} fs_in;

void main(void)
{
    o_color = texture(tex, fs_in.tc) * (max(0.0, normalize(fs_in.normal).z) * 0.7 + 0.3);
}
