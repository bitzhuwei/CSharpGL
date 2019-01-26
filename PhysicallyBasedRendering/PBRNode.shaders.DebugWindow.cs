using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    partial class PBRNode
    {
        private const string debugWindowVertexCode = @"#version 330 core
layout(location = 0) in vec3 vPosition;
layout(location = 1) in vec2 vTexcoord;

out vec2 fTexcoord;

void main()
{
	gl_Position=vec4(vPosition,1.0);
	fTexcoord=vTexcoord;
}
";

        private const string debugWindowFragmentCode = @"#version 330 core


uniform sampler2D diffuseMap;
in vec2 fTexcoord;
out vec4 fColor;
void main()
{
    vec3 col=texture(diffuseMap,fTexcoord).rgb;
    fColor =vec4(col,1.0f);
} 
";

    }
}
