#version 420 core

/*
 * OpenGL Programming Guide - Order Independent Transparency Example
 *
 * This is the resolve shader for order independent transparency.
 */

// The per-pixel image containing the head pointers
layout (binding = 0, r32ui) uniform uimage2D head_pointer_image;
// Buffer containing linked lists of fragments
layout (binding = 1, rgba32ui) uniform uimageBuffer list_buffer;

// This is the output color
layout (location = 0) out vec4 color;

// This is the maximum number of overlapping fragments allowed
#define MAX_FRAGMENTS 40

// Temporary array used for sorting fragments
uvec4 fragment_list[MAX_FRAGMENTS];

void main(void)
{
    uint current_index;
    uint fragment_count = 0;

    current_index = imageLoad(head_pointer_image, ivec2(gl_FragCoord).xy).x;

    while (current_index != 0 && fragment_count < MAX_FRAGMENTS)
    {
        uvec4 fragment = imageLoad(list_buffer, int(current_index));
        fragment_list[fragment_count] = fragment;
        current_index = fragment.x;
        fragment_count++;
    }

	if (fragment_count > 1)
	{
		for (uint i = 0; i < fragment_count - 1; i++)
		{
			uint p = i;
			uint depth1 = (fragment_list[p].z);
			for (uint j = i + 1; j < fragment_count; j++)
			{
				uint depth2 = (fragment_list[j].z);
				if (depth1 < depth2)
				{
					p = j; depth1 = depth2;
				}
			}
			if (p != i)
			{
				uvec4 tmp = fragment_list[p];
				fragment_list[p] = fragment_list[i];
				fragment_list[i] = tmp;
			}
		}	
	}

    vec4 final_color = vec4(0.0);

    for (uint i = 0; i < fragment_count; i++)
    {
        vec4 modulator = unpackUnorm4x8(fragment_list[i].y);

        final_color = mix(final_color, modulator, modulator.a + fragment_list[i].w / 255);
    }

    color = final_color;
    // color = vec4(float(fragment_count) / float(MAX_FRAGMENTS));
}
