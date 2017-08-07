using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    partial class DemoNode
    {
        private const string updateVert = @"#version 330

in vec3 inPosition;// world space.
in vec3 inVelocity;// world space.

out vec3 outPosition;// world space
out vec3 outVelocity;// world space

uniform float time = 0.01;

void main()
{
    vec3 pos = inPosition + inVelocity * time;
    if (pos.x >3 || pos.y > 3 || pos.z > 3)
    {
        pos = vec3(0, 0, 0);
    }
    
    outPosition = pos;
    outVelocity = inVelocity;

    gl_Position = vec4(pos, 1); 
}
";
    }
}
