using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace OrderIndependentTransparency
{
    public partial class OITNode : PickableNode
    {
        private const string buildListsVert = @"#version 330

in vec3 inPosition;
in vec3 inNormal;

uniform mat4 mvpMatrix;

uniform float minAlpha = 0.5f;

out vec4 passColor;

void main(void)
{
    vec3 color = inNormal;
    if (color.r < 0) { color.r = -color.r; }
    if (color.g < 0) { color.g = -color.g; }
    if (color.b < 0) { color.b = -color.b; }
	vec3 normalized = normalize(color);
	float variance = (normalized.r - normalized.g) * (normalized.r - normalized.g);
	variance += (normalized.g - normalized.b) * (normalized.g - normalized.b);
	variance += (normalized.b - normalized.r) * (normalized.b - normalized.r);
	variance = variance / 2.0f;// range from 0.0f - 1.0f
	float a = (0.75f - minAlpha) * (1.0f - variance) + minAlpha;
    passColor = vec4(normalized, a);

    gl_Position = mvpMatrix * vec4(inPosition, 1.0f);
}
";
        private const string buildListsFrag = @"#version 420 core

layout (early_fragment_tests) in;

layout (binding = 0, offset = 0) uniform atomic_uint atomicCounter;
layout (binding = 0, r32ui) uniform uimage2D heads;
layout (binding = 1, rgba32ui) uniform writeonly uimageBuffer lstBuffer;

in vec4 passColor;

layout (location = 0) out vec4 color;

void main(void)
{
    uint index;
    uint old_head;
    uvec4 item;

    index = atomicCounterIncrement(atomicCounter);

    old_head = imageAtomicExchange(heads, ivec2(gl_FragCoord.xy), uint(index));

    item.x = old_head;
    item.y = packUnorm4x8(passColor);
    item.z = floatBitsToUint(gl_FragCoord.z);
	item.w = 255 / 4;

    imageStore(lstBuffer, int(index), item);

    //color = passColor;
	discard;
}
";
    }
}
