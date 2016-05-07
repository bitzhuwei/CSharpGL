#version 420 core

layout (early_fragment_tests) in;

layout (binding = 0, r32ui) uniform uimage2D head_pointer_image;
layout (binding = 1, rgba32ui) uniform writeonly uimageBuffer list_buffer;

layout (binding = 0, offset = 0) uniform atomic_uint list_counter;

layout (location = 0) out vec4 color;

in vec4 surface_color;

uniform vec3 light_position = vec3(40.0, 20.0, 100.0);

void main(void)
{
    uint index;
    uint old_head;
    uvec4 item;

    index = atomicCounterIncrement(list_counter);

    old_head = imageAtomicExchange(head_pointer_image, ivec2(gl_FragCoord.xy), uint(index));

    item.x = old_head;
    item.y = packUnorm4x8(surface_color);
    item.z = floatBitsToUint(gl_FragCoord.z);
	item.w = 255 / 4;

    imageStore(list_buffer, int(index), item);

    color = surface_color;
}
