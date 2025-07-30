﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.DualPeeling {
    public static partial class Shaders {
        public const string blendVert = @"#version 330 core 
  
layout(location = 0) in vec2 inPosition;
 
void main()
{  
    //get the clip space position from the object space position
    gl_Position = vec4(inPosition.xy * 2 - 1.0, 0, 1);
}
";
        public const string blendFrag = @"#version 330 core

uniform sampler2DRect tempTexture; //intermediate blending result

layout(location = 0) out vec4 outColor; //fragment shader output

void main()
{
    //return the intermediate blending result
    outColor = texture(tempTexture, gl_FragCoord.xy); 

    // for occlusion query.
    if (outColor.a == 0) discard;
}
";

    }
}
