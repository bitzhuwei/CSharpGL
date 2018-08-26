using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDD02_LayeredEngraving.ComputeShader
{
    public static partial class Shaders
    {
        public const string blendVert = @"#version 330 core 

in vec2 inPosition;
 
void main()
{  
    gl_Position = vec4(inPosition * 2 - 1.0, 0, 1);
}
";
        public const string blendFrag = @"#version 330 core

uniform sampler2DRect tempTexture;

out vec4 outColor;

void main()
{
    //return the intermediate blending result
    outColor = texture(tempTexture, gl_FragCoord.xy); 

    if (outColor.a == 0) discard;
}
";

    }
}
