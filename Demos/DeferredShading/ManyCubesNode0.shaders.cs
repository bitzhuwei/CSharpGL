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

in vec3 vPosition; // per-vertex position
in vec3 vColor; // per-vertex normal

uniform mat4 MVP; // combined model view projection matrix

out vec3 passColor;

void main()
{
	gl_Position = MVP * vec4(vPosition, 1);
    passColor = vColor;
}
";
        private const string regularFrag = @"#version 330 core

in vec3 passColor;

layout (location = 0) out vec3 vFragColor;

void main()
{
    vFragColor = passColor;
}
";
    }
}
