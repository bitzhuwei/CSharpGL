﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ComputeShader.EdgeDetection {
    partial class EdgeDetectNode {
        private const string computeShader = @"#version 430 core

layout (local_size_x = 512) in;

layout (rgba32f, binding = 0) uniform image2D inImage;
layout (rgba32f, binding = 1) uniform image2D outImage;

shared vec4 scanline[512];

void main(void)
{
    ivec2 pos = ivec2(gl_GlobalInvocationID.xy);
    scanline[pos.x] = imageLoad(inImage, pos);
    barrier();
	// Compute our result and write it back to the image
	vec4 result = scanline[min(pos.x + 1, 511)] - scanline[max(pos.x - 1, 0)];
    imageStore(outImage, pos.yx, result);
}
";
    }
}
