using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class ManyCubesNode0
    {
        private const string regularVert = @"#version 330 core

in vec3 inPosition; // per-vertex position
in vec3 inColor; // per-vertex normal

uniform mat4 mvpMat; // combined model view projection matrix

out vec3 passColor;

void main()
{
	gl_Position = mvpMat * vec4(inPosition, 1);
    passColor = inColor;
}
";
        private const string regularFrag = @"#version 330 core

in vec3 passColor;

layout (location = 0) out vec3 outColor;

void main()
{
    outColor = passColor;
}
";
    }
}
