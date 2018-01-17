using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace VolumeRendering.Slicing
{
    partial class SlicesNode
    {
        private const string defaultVert = @"#version 330 core
  
layout(location = 0) in vec3 vVertex;	//object space vertex position

//uniform
uniform mat4 MVP;		//combined modelview projection matrix

smooth out vec3 vUV;	//3D texture coordinates for texture lookup in the fragment shader

void main()
{  
	//get the clipspace position 
	gl_Position = MVP*vec4(vVertex.xyz,1);

	//get the 3D texture coordinates by adding (0.5,0.5,0.5) to the object space 
	//vertex position. Since the unit cube is at origin (min: (-0.5,-0.5,-0.5) and max: (0.5,0.5,0.5))
	//adding (0.5,0.5,0.5) to the unit cube object space position gives us values from (0,0,0) to 
	//(1,1,1)
	vUV = vVertex + vec3(0.5);
}
";
        private const string defaultFrag = @"#version 330 core

layout(location = 0) out vec4 vFragColor;	//fragment shader output

smooth in vec3 vUV;				//3D texture coordinates form vertex shader 
								//interpolated by rasterizer

//uniform
uniform sampler3D volume;		//volume dataset

void main()
{
	//Here we sample the volume dataset using the 3D texture coordinates from the vertex shader.
	//Note that since at the time of texture creation, we gave the internal format as GL_RED
	//we can get the sample value from the texture using the red channel. Here, we set all 4
	//components as the sample value in the texture which gives us a shader of grey.
	vFragColor = texture(volume, vUV).rrrr;
}
";

    }
}
