#version 430 core

// 2D image to store head pointers
layout (binding = 0, r32ui) coherent uniform uimage2D head_pointer;

void main(void)
{
    ivec2 P = ivec2(gl_FragCoord.xy);

    imageStore(head_pointer, P, uvec4(0xFFFFFFFF));
}
