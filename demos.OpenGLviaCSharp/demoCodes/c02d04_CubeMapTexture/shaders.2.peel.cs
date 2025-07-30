using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d04_CubeMapTexture {
    public static partial class Shaders {
        public const string peelVert = @"#version 330 core
  
in vec3 inPosition; //object space vertex position.

uniform mat4 mvpMat;  //combined modelview projection matrix>

out vec3 passTexCoord;

void main()
{  
    //get the clipspace vertex position.
    gl_Position = mvpMat * vec4(inPosition.xyz, 1);

    passTexCoord = inPosition; // Special property for the Cube model.
}
";
        public const string peelFrag = @"#version 330 core

in vec3 passTexCoord;

//uniforms
uniform samplerCube cubeTex;
uniform sampler2DRect depthTexture;
uniform float alpha = 0.25;

out vec4 outColor;

void main()
{
    //read the depth value from the depth texture.
    float frontDepth = texture(depthTexture, gl_FragCoord.xy).r;

    //compare the current fragment depth with the depth in the depth texture.
    //if it is less, discard the current fragment.
    if(gl_FragCoord.z <= frontDepth) discard;
	
    //otherwise set the given color uniform as the final output.
    vec4 vColor = texture(cubeTex, passTexCoord);
    outColor = vec4(vColor.rgb * alpha, alpha);
}
";
    }
}
