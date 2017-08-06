using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    partial class SimpleTransformFeedBackNode
    {
        private const string renderVert = @"#version 330

in vec3 inPosition; // world space

uniform mat4 mvpMatrix;

void main()
{
    gl_Position = mapMatrix * vec4(inPosition, 1);
}
";
        private const string renderFrag = @"#version 330

uniform vec3 color = vec3(1, 0, 0);

out vec4 vFragColor;

void main()
{
    vFragColor = vec4(color, 1);
}
";
    }
}
