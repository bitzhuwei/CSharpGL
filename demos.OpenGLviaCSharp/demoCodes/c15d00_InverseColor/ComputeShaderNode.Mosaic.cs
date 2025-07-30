using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d00_InverseColor {
    partial class ComputeShaderNode {
        private const string mosaicComp = @"#version 430 core

layout (local_size_x = 8, local_size_y = 8) in;

layout (rgba32f, binding = 0) uniform image2D inImage;
layout (rgba32f, binding = 1) uniform image2D outImage;

shared vec4 colors[64];

void main(void)
{
    ivec2 pos = ivec2(gl_GlobalInvocationID.xy);
    colors[gl_LocalInvocationIndex] = imageLoad(inImage, pos);
    barrier();

	vec4 result = vec4(0);
    for (int i = 0; i < 16; i++)
    {
        result += (colors[i] / 16);
    }

    imageStore(outImage, pos, result);
}
";
    }
}
