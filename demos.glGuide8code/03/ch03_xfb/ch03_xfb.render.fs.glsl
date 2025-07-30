#version 410

layout (location = 0) out vec4 color;

in vec3 vs_fs_normal;

void main(void)
{
    color = vec4(0.0, 0.2, 0.0, 1.0) + vec4(0.2, 0.5, 0.4, 1.0) * abs(vs_fs_normal.z) + vec4(0.8, 0.9, 0.7, 1.0) * pow(abs(vs_fs_normal.z), 70.0);
};