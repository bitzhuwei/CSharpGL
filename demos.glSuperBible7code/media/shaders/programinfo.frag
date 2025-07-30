#version 420 core

out vec4 color;
layout (location = 2) out ivec2 data;
out float extra;

in BLOCK0
{
    vec2 tc;
    vec4 color;
    flat int foo;
} fs_in0;

in BLOCK1
{
    vec3 normal[4];
    flat ivec3 layers;
    double bar;
} fs_in1;

void main(void)
{
    float val = abs(fs_in0.tc.x + fs_in0.tc.y) * 20.0f;
    color = vec4(fract(val) >= 0.5 ? 1.0 : 0.25) + fs_in1.normal[3].xyzy;
    data = ivec2(1, 2);
    extra = 9.0;
}