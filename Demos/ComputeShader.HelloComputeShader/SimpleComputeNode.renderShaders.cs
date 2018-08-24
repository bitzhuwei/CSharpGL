using CSharpGL;
using System;
using System.IO;

namespace ComputeShader.HelloComputeShader
{
    partial class SimpleComputeNode
    {
        private const string renderVert = @"#version 430 core

in vec3 position;

uniform mat4 projectionMat;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void)
{
    gl_Position = projectionMat * viewMatrix * modelMatrix * vec4(position, 1.0f);
}
";
        private const string renderFrag = @"#version 430 core

layout (location = 0) out vec4 color;

uniform sampler2D outImage;

void main(void)
{
    color = texture(outImage, vec2(gl_FragCoord.xy) / vec2(textureSize(outImage, 0)));
}
";
    }
}
