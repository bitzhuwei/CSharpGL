using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d04_CubeMapTexture
{
    public static partial class Shaders
    {
        public const string initVert = @"#version 330 core
  
in vec3 vVertex; //object space vertex position

//uniform
uniform mat4 MVP;  //combined modelview projection matrix

out vec3 passTexCoord;

void main()
{  
	//get the clipspace vertex position
	gl_Position = MVP*vec4(vVertex.xyz,1);

    passTexCoord = vVertex; // Special property for the Cube model.
}
";
        public const string initFrag = @"#version 330 core

in vec3 passTexCoord;

uniform samplerCube cubeTex;	//texture uniform
uniform float alpha = 0.25;

out vec4 vFragColor; //output fragment colour

void main()
{
    vec4 vColor = texture(cubeTex, passTexCoord);
    vFragColor = vec4(vColor.rgb * alpha, 1.0 - alpha);
}
";
    }
}
