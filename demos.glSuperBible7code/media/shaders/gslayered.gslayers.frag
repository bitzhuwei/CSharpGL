#version 420 core

in GS_OUT
{
    vec4 color;
    vec3 normal;
} fs_in;

layout (location = 0) out vec4 color;

void main(void)
{
    // color = vec4(1.0); // fs_in.color;
    color = vec4(abs(fs_in.normal.z)) * fs_in.color;
}
