using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d00_InverseColor
{
    partial class EdgeDetectNode
    {
        private const string inverseColorComp = @"#version 430 core

layout (local_size_x = 512) in;

layout (rgba32f, binding = 0) uniform image2D inImage;
layout (rgba32f, binding = 1) uniform image2D outImage;

void main(void)
{
    ivec2 pos = ivec2(gl_GlobalInvocationID.xy);
    vec4 color = imageLoad(inImage, pos);
    vec4 inversedColor = vec4(1.0) - color;
    imageStore(outImage, pos, inversedColor);
}
";
    }
}
