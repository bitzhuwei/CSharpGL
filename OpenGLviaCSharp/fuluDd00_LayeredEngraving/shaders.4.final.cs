using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDd00_LayeredEngraving
{
    public static partial class Shaders
    {
        public const string finalVert = @"#version 330 core 
  
layout(location = 0) in vec2 vVertex; //object space vertex position
 
void main()
{  
    //get the clip space position from the object space position
    gl_Position = vec4(vVertex.xy*2 - 1.0,0,1);
}
";
        public const string finalFrag = @"#version 330 core

layout(location = 0) out vec4 vFragColor;	//fragment shader output

//uniforms
uniform sampler2DRect colorTexture;	//colour texture from previous pass
uniform vec4 vBackgroundColor;		//background colour
uniform bool useBackground = true;

void main()
{
    //get the colour from the colour buffer
    vec4 color = texture(colorTexture, gl_FragCoord.xy);
    //combine the colour read from the colour texture with the background colour
    //by multiplying the colour alpha with the background colour and adding the 
    //product to the given colour uniform
    if (useBackground) {
	    vFragColor = color + vBackgroundColor*color.a;
    }
    else {
        vFragColor = color;
    }
}
";

    }
}
