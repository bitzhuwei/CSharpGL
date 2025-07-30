﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.FrontToBackPeeling {
    public static partial class Shaders {
        public const string peelVert = @"#version 330 core
  
layout(location = 0) in vec3 inPosition;

//uniform
uniform mat4 mvpMat;

void main()
{  
    //get the clipspace vertex position
    gl_Position = mvpMat * vec4(inPosition.xyz, 1);
}
";
        public const string peelFrag = @"#version 330 core

layout(location = 0) out vec4 outColor;

//uniforms
uniform vec4 vColor;
uniform sampler2DRect  depthTexture;

void main()
{
    //read the depth value from the depth texture
    float frontDepth = texture(depthTexture, gl_FragCoord.xy).r;

    //compare the current fragment depth with the depth in the depth texture
    //if it is less, discard the current fragment
    if(gl_FragCoord.z <= frontDepth) discard;
	
    //otherwise set the given color uniform as the final output
    outColor = vec4(vColor.rgb * vColor.a, vColor.a);
}
";
    }
}
