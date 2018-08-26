using CSharpGL;
using System;
using System.IO;

namespace ComputeShader.HelloComputeShader
{
    partial class SimpleComputeNode
    {
        private const string computeShader = @"#version 430 core

layout (local_size_x = 32, local_size_y = 16) in;


layout (binding = 0, rgba32f) uniform image2D outImage;

uniform bool reset = false;

void main(void)
{
    if (reset) 
    {
        imageStore(outImage,
		    ivec2(gl_GlobalInvocationID.xy),
            vec4(1,1,1,1));
    }
    else 
    {
        imageStore(outImage,
		    ivec2(gl_GlobalInvocationID.xy),
            vec4(vec2(gl_LocalInvocationID.xy) / vec2(gl_WorkGroupSize.xy), 0.0, 0.0));
    }
}
";
    }
}
