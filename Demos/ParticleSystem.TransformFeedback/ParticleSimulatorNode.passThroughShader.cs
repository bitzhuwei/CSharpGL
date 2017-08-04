using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    public partial class ParticleSimulatorNode
    {
        private const string passThroughVert = @"#version 330 core
precision highp float;

layout (location=0) in vec4 position;	//object space vertex position 
uniform mat4 MVP;						//combined modelview projection matrix

void main() 
{  
	//get the clip space position
	gl_Position = MVP*vec4(position.xyz, 1.0);		
}
";
        private const string passThroughFrag = @"#version 330 core

layout(location=0) smooth out vec4 vFragColor;	//fragment shader output
uniform vec4 vColor;							//uniform colour to use as fragment colour

void main()
{ 		
	//assign the input varying as the output fragment colour
	vFragColor = vColor;  
}
";
    }
}
