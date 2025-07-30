#version 410

layout (location = 0) out vec4 color;

in vec3 vs_fs_normal;
in vec4 vs_fs_color;

void main(void)
{
    color = vs_fs_color * (0.1 + abs(vs_fs_normal.z)) + vec4(0.8, 0.9, 0.7, 1.0) * pow(abs(vs_fs_normal.z), 40.0);
}