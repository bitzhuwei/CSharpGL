using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDD02_LayeredEngraving.ComputeShader {
    public static partial class Shaders {
        public const string initVert = @"#version 330 core

in vec3 inPosition;

uniform mat4 mvpMat;

void main()
{  
	gl_Position = mvpMat * vec4(inPosition, 1);
}
";
        public const string initFrag = @"#version 330 core

uniform vec4 color;

out vec4 outColor;

void main()
{
    outColor = vec4(color.rgb, gl_FragCoord.z);
}
";

    }
}
