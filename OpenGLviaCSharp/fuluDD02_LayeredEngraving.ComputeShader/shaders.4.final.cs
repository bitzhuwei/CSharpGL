using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDD02_LayeredEngraving.ComputeShader
{
    public static partial class Shaders
    {
        public const string finalVert = @"#version 330 core 
  
in vec2 inPosition;
 
void main()
{  
    //get the clip space position from the object space position
    gl_Position = vec4(inPosition.xy * 2 - 1.0,0,1);
}
";
        public const string finalFrag = @"#version 330 core

out vec4 outColor;

//uniforms
uniform sampler2DRect colorTexture;	//color texture from previous pass
uniform vec4 backgroundColor;		//background color
uniform bool useBackground = true;

void main()
{
    //get the color from the color buffer
    vec4 color = texture(colorTexture, gl_FragCoord.xy);
    //combine the color read from the color texture with the background color
    //by multiplying the color alpha with the background color and adding the 
    //product to the given color uniform
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
