#version 430 core

// 2D image to store head pointers
layout (binding = 0, r32ui) coherent uniform uimage2D head_pointer;

// Shader storage buffer containing appended fragments
struct list_item
{
    vec4        color;
    float       depth;
    int         facing;
    uint        next;
};

layout (binding = 0, std430) buffer list_item_block
{
    list_item   item[];
};

layout (location = 0) out vec4 color;

const uint max_fragments = 10;

void main(void)
{
    uint frag_count = 0;
    float depth_accum = 0.0;
    ivec2 P = ivec2(gl_FragCoord.xy);

    uint index = imageLoad(head_pointer, P).x;

    while (index != 0xFFFFFFFF && frag_count < max_fragments)
    {
        list_item this_item = item[index];

        if (this_item.facing != 0)
        {
            depth_accum -= this_item.depth;
        }
        else
        {
            depth_accum += this_item.depth;
        }

        index = this_item.next;
        frag_count++;
    }

    depth_accum *= 3000.0;

    color = vec4(depth_accum, depth_accum, depth_accum, 1.0);
}
