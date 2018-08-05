using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d00_InverseColor
{
    partial class EdgeDetectNode
    {
        private const string fuzzyComp = @"#version 430 core

layout (local_size_x = 512) in;

layout (rgba32f, binding = 0) uniform image2D inImage;
layout (rgba32f, binding = 1) uniform image2D outImage;

uniform int strength = 3;

void main(void)
{
    ivec2 pos = ivec2(gl_GlobalInvocationID.xy);
    vec4 color = vec4(0);
    for (int deltaX = -strength; deltaX <= strength; deltaX++)
    {
        for (int deltaY = -strength;deltaY <= strength; deltaY++)
        {
            int x = min(pos.x + deltaX, 511); x = max(x, 0);
            int y = min(pos.y + deltaY, 511); y = max(y, 0);
            color += imageLoad(inImage, ivec2(x, y));
        }
    }
    color /= ((strength * 2 + 1) * (strength * 2 + 1));

    imageStore(outImage, pos, color);
}
";
    }
}
