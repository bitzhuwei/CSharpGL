using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDd00_VolumeMapping
{
    public static partial class Shaders
    {
        public const string engraveComp = @"#version 430 core

layout (local_size_x = 1) in;

layout (rgba32f, binding = 0) uniform image2D input_image;
layout (r8ui, binding = 1) uniform uimage3D output_image;

uniform float depth;

void main(void)
{
    ivec2 pos = ivec2(gl_GlobalInvocationID.xy);
    vec4 color = imageLoad(input_image, pos);
	uint d = uint(depth * color.a / 256.0);
	uint value = uint(color.r * 0.299 + color.g * 0.587 + color.b * 0.114);
    imageStore(output_image, ivec3(int(pos.x), int(pos.y), d), uvec4(value));
}
";

    }
}
