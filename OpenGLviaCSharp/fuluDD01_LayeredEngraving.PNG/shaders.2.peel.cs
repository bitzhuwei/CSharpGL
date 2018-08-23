using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace fuluDD01_LayeredEngraving.PNG
{
    public static partial class Shaders
    {
        public const string peelVert = @"#version 330 core

in vec3 inPosition; //object space vertex position

//uniform
uniform mat4 mvpMat;  //combined modelview projection matrix

void main()
{  
    //get the clipspace vertex position
    gl_Position = mvpMat * vec4(inPosition, 1);
}
";
        public const string peelFrag = @"#version 330 core

out vec4 outColor;	//fragment shader output

//uniforms
uniform vec4 color;						//solid colour 
uniform sampler2DRect  depthTexture;		//depth texture 

void main()
{
    //read the depth value from the depth texture
    float frontDepth = texture(depthTexture, gl_FragCoord.xy).r;

    //compare the current fragment depth with the depth in the depth texture
    //if it is less, discard the current fragment
    if(gl_FragCoord.z <= frontDepth) discard;
	
    //otherwise set the given color uniform as the final output
    outColor = vec4(color.rgb, gl_FragCoord.z);
}
";
    }
}
