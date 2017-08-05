using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    public partial class ParticleSimulatorNode
    {
        /// <summary>
        /// render(and pass to another data node via transform feedback)
        /// </summary>
        private const string renderVert = @"#version 330 core
precision highp float;

layout (location=0) in vec4 position;	//particle object space position

uniform mat4 MVP;						//combine modelview projection matrix

out vec4 color;					//output colour varying to the fragment shader 

//colormap colours
const vec3 RED = vec3(1,0,0);
const vec3 GREEN = vec3(0,1,0);
const vec3 YELLOW = vec3(1,1,0); 

void main() 
{  
	//store the clip space position
	gl_Position = MVP*vec4(position.xyz, 1.0);	
	//get the t value for interpolation of the colour map colours 
	//using the distance of the particle from the origin, if it is 
	//3 or greater, the particle colour is changed to yellow
	float t =  1.0- length(position.xyz)/3.0;	
	color = vec4(mix(YELLOW, RED, t), t);
}
";
        /// <summary>
        /// render(and pass to another data node via transform feedback)
        /// </summary>
        private const string renderFrag = @"#version 330 core

layout(location=0) out vec4 vFragColor;	//fragment shader output
in vec4 color;							//input interpolated colour from the vertex shader

void main()
{ 		
	//simply assign the interpolated colour as the fragment output
	vFragColor = color;  	
}
";
    }
}
