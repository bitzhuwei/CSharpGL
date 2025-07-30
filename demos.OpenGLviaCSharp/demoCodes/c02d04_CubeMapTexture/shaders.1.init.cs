﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d04_CubeMapTexture {
    public static partial class Shaders {
        public const string initVert = @"#version 330 core
  
in vec3 inPosition; //object space vertex position.

uniform mat4 mvpMat;  //combined modelview projection matrix.

out vec3 passTexCoord;

void main()
{  
	//get the clipspace vertex position.
	gl_Position = mvpMat * vec4(inPosition.xyz, 1);

    passTexCoord = inPosition; // Special property for the Cube model.
}
";
        public const string initFrag = @"#version 330 core

in vec3 passTexCoord;

uniform samplerCube cubeTex;
uniform float alpha = 0.25;

out vec4 outColor;

void main()
{
    vec4 vColor = texture(cubeTex, passTexCoord);
    outColor = vec4(vColor.rgb * alpha, 1.0 - alpha);
}
";
    }
}
