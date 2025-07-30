using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDD02_LayeredEngraving.ComputeShader {
    public static partial class Shaders {
        public const string engraveXComp = @"#version 430 core

layout (local_size_x = 256) in;

layout (rgba32f, binding = 0) uniform image2D inImage;
layout (std430, binding = 1) buffer outputBuffer {
    uint outBuffer[];
};

//uniform int width = 256;
uniform int height = 256;
uniform int depth = 256;

void main(void)
{
    uint d = gl_GlobalInvocationID.x; // or uint w = gl_LocalInvocationID.x;
    uint h = gl_GlobalInvocationID.y; // or uint h = gl_WorkGroupID.y;
    vec4 color = imageLoad(inImage, ivec2(d, h));
    uint w = uint(depth * color.a);
    if (w == depth) { w = depth - 1; }
    uint index = uint(w * height * depth + h * depth + d);
    color += unpackUnorm4x8(outBuffer[index]);
    outBuffer[index] = packUnorm4x8(color);
}
";

        public const string engraveYComp = @"#version 430 core

layout (local_size_x = 256) in;

layout (rgba32f, binding = 0) uniform image2D inImage;
layout (std430, binding = 1) buffer outputBuffer {
    uint outBuffer[];
};

//uniform int width = 256;
uniform int height = 256;
uniform int depth = 256;

void main(void)
{
    uint w = gl_GlobalInvocationID.x; // or uint w = gl_LocalInvocationID.x;
    uint d = gl_GlobalInvocationID.y; // or uint h = gl_WorkGroupID.y;
    vec4 color = imageLoad(inImage, ivec2(w, d));
    uint h = uint(depth * color.a);
    if (h == depth) { h = depth - 1; }
    uint index = uint(w * height * depth + h * depth + d);
	color += unpackUnorm4x8(outBuffer[index]);
    outBuffer[index] = packUnorm4x8(color);
}
";

        public const string engraveZComp = @"#version 430 core

layout (local_size_x = 256) in;

layout (rgba32f, binding = 0) uniform image2D inImage;
layout (std430, binding = 1) buffer outputBuffer {
    uint outBuffer[];
};

//uniform int width = 256;
uniform int height = 256;
uniform int depth = 256;

void main(void)
{
    uint w = gl_GlobalInvocationID.x; // or uint w = gl_LocalInvocationID.x;
    //uint h = height - gl_GlobalInvocationID.y - 1; // or uint h = gl_WorkGroupID.y;
    uint h = gl_GlobalInvocationID.y; // or uint h = gl_WorkGroupID.y;
    vec4 color = imageLoad(inImage, ivec2(w, h));
    uint d = uint(depth * color.a);
    if (d == depth) { d = depth - 1; }
    uint index = uint(w * height * depth + h * depth + d);
	color += unpackUnorm4x8(outBuffer[index]);
    outBuffer[index] = packUnorm4x8(color);
}
";

    }
}
