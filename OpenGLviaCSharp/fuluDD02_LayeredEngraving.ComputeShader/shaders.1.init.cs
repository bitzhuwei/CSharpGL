using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDD02_LayeredEngraving.ComputeShader
{
    public static partial class Shaders
    {
        public const string initVert = @"#version 330 core

in vec3 inPosiiton; //object space vertex position

//uniform
uniform mat4 mvpMat;  //combined modelview projection matrix

void main()
{  
	//get the clipspace vertex position
	gl_Position = mvpMat * vec4(inPosiiton, 1);
}
";
        public const string initFrag = @"#version 330 core

out vec4 outColor; //output fragment colour

uniform vec4 color;	//colour uniform

void main()
{
    outColor = vec4(color.rgb, gl_FragCoord.z);
}
";

    }
}
