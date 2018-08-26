using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c14d02_DoubleTransformFeedbakObjects
{
    partial class DemoNode
    {
        private const string renderVert = @"#version 330

in vec3 inPosition; // world space

uniform mat4 mvpMat;
vec3 velocities[3] = vec3[3](vec3(1, 0, 0), vec3(0, 1, 0), vec3(0, 0, 1));

out vec3 passColor;

void main()
{
    gl_Position = mvpMat * vec4(inPosition, 1);
    passColor = velocities[gl_VertexID];
}
";
        private const string renderFrag = @"#version 330

in vec3 passColor;

out vec4 outColor;

void main()
{
    outColor = vec4(passColor, 1);
}
";
    }
}
