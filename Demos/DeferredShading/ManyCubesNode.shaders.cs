using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class ManyCubesNode
    {
        private const string firstPassVert = @"#version 330 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMat;

out vec3 passColor;

void main()
{
	gl_Position = mvpMat * vec4(inPosition, 1);
    passColor = inColor;
}
";
        private const string firstPassFrag = @"#version 330 core

in vec3 passColor;

layout (location = 0) out vec3 outColor;

void main()
{
    outColor = passColor;
}
";

    }
}
