using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d04_CubeMapTexture {
    public static partial class Shaders {
        public const string finalVert = @"#version 330 core 
  
layout(location = 0) in vec2 inPosition; //object space vertex position.
 
void main()
{  
    //get the clip space position from the object space position.
    gl_Position = vec4(inPosition.xy * 2 - 1.0, 0, 1);
}
";
        public const string finalFrag = @"#version 330 core

layout(location = 0) out vec4 outColor;

uniform sampler2DRect colorTexture;	//color texture from previous pass.
uniform vec4 backgroundColor;
uniform bool useBackground = true;

void main()
{
    //get the color from the color buffer.
    vec4 color = texture(colorTexture, gl_FragCoord.xy);
    if (useBackground) {
        outColor = color + backgroundColor * color.a;
    }
    else {
        outColor = color;
    }
}
";

    }
}
