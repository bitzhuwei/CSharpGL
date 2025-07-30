#version 410 core

out vec4 color;

in VS_OUT
{
    vec3 normal;
    vec4 color;
} fs_in;

void main(void)
{
    vec3 N = normalize(fs_in.normal);

    color = fs_in.color * abs(N.z);
}
