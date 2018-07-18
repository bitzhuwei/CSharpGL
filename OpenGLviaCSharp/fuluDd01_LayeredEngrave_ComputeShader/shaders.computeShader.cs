using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDd01_LayeredEngrave_ComputeShader
{
    public static partial class Shaders
    {
        public const string engraveComp = @"#version 430 core

layout (local_size_x = 256) in;

layout (rgba32f, binding = 0) uniform image2D input_image;
layout (std430, binding = 1) buffer outputBuffer {
    uint outBuffer[];
};

//uniform int width = 256;
uniform int height = 256;
uniform int depth = 256;

void main(void)
{
    uint w = gl_GlobalInvocationID.x; // or uint w = gl_LocalInvocationID.x;
    uint h = gl_GlobalInvocationID.y; // or uint h = gl_WorkGroupID.y;
    vec4 color = imageLoad(input_image, ivec2(w, h));
    uint d = uint(depth * color.a);
    if (d == depth) { d = depth - 1; }
    uint index = uint(w * height * depth + h * depth + d);
	uint value = uint((color.r * 0.299 + color.g * 0.587 + color.b * 0.114) * 255);
    outBuffer[index] = value;
}
";
        //        public const string engraveComp = @"#version 430 core
        //
        //layout (local_size_x = 256) in;
        //
        //layout (rgba32f, binding = 0) uniform image2D input_image;
        //layout (r8ui, binding = 1) uniform uimage3D output_image;
        //
        //uniform float depth;
        //
        //void main(void)
        //{
        //    ivec2 pos = ivec2(gl_GlobalInvocationID.xy);
        //    vec4 color = imageLoad(input_image, pos);
        //	uint d = uint(depth * color.a / 256.0);
        //	uint value = uint(color.r * 0.299 + color.g * 0.587 + color.b * 0.114);
        //    imageStore(output_image, ivec3(int(pos.x), int(pos.y), d), uvec4(pos, pos));
        //}
        //";

    }
}
