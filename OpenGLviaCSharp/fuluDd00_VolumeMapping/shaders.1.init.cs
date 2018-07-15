using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDd00_VolumeMapping
{
    public static partial class Shaders
    {
        public const string initVert = @"#version 330 core
  
layout(location = 0) in vec3 vVertex; //object space vertex position

//uniform
uniform mat4 MVP;  //combined modelview projection matrix

void main()
{  
	//get the clipspace vertex position
	gl_Position = MVP*vec4(vVertex.xyz,1);
}
";
        public const string initFrag = @"#version 330 core

layout(location = 0) out vec4 vFragColor; //output fragment colour

uniform vec4 vColor;	//colour uniform

void main()
{
    vFragColor = vec4(vColor.rgb, gl_FragCoord.z);
}
";

    }
}
