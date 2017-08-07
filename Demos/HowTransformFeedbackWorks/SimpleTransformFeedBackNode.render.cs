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
in vec3 inVelocity;

uniform mat4 mvpMatrix;

out vec3 passColor;

void main()
{
    gl_Position = mvpMatrix * vec4(inPosition, 1);
    passColor = inVelocity;
}
";
        private const string renderFrag = @"#version 330

in vec3 passColor;

out vec4 vFragColor;

void main()
{
    vFragColor = vec4(passColor, 1);
}
";
    }
}
