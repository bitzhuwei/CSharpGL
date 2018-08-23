using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.DualPeeling
{
    public static partial class Shaders
    {
        public const string finalVert = @"#version 330 core 
  
layout(location = 0) in vec2 inPosition; //object space vertex position
 
void main()
{  
    //get the clip space position from the object space position
    gl_Position = vec4(inPosition.xy * 2 - 1.0, 0, 1);
}
";
        public const string finalFrag = @"#version 330 core

layout(location = 0) out vec4 outColor;	//fragment shader output

uniform sampler2DRect DepthBlenderTex;
uniform sampler2DRect FrontBlenderTex;
uniform sampler2DRect BackBlenderTex;

void main(void)
{
    vec4 frontColor = texture(FrontBlenderTex, gl_FragCoord.xy);
    vec3 backColor = texture(BackBlenderTex, gl_FragCoord.xy).rgb;
    float alphaMultiplier = 1.0 - frontColor.w;

    vec3 color;
    // front + back
    color = frontColor.xyz + backColor * alphaMultiplier;
	
    // front blender
    //color = frontColor + vec3(alphaMultiplier);
	
    // back blender
    //color = backColor;
    
    outColor = vec4(color, frontColor.a);
}

";

    }
}
