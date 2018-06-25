using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c14d02_DoubleTransformFeedbakObjects
{
    partial class DemoNode
    {
        private const string updateVert = @"#version 330

in vec3 inPosition;

out vec3 outPosition;

uniform float time = 0.01;
vec3 velocities[3] = vec3[3](vec3(1, 0, 0), vec3(0, 1, 0), vec3(0, 0, 1));

void main()
{
    vec3 pos = inPosition + velocities[gl_VertexID] * time;
    if (pos.x > 1 || pos.y > 1 || pos.z > 1)
    {
        pos = vec3(0, 0, 0);
    }
    
    outPosition = pos;

    gl_Position = vec4(pos, 1); 
}
";
    }
}
