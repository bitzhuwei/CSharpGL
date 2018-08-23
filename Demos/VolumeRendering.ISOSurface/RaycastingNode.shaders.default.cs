using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace VolumeRendering.ISOSurface
{
    partial class RaycastingNode
    {
        private const string defaultVert = @"#version 330 core
  
layout(location = 0) in vec3 inPosition; //object space vertex position

//uniform
uniform mat4 mvpMat;   //combined modelview projection matrix

smooth out vec3 vUV; //3D texture coordinates for texture lookup in the fragment shader

void main()
{  
	//get the clipspace position 
	gl_Position = mvpMat*vec4(inPosition.xyz,1);

	//get the 3D texture coordinates by adding (0.5,0.5,0.5) to the object space 
	//vertex position. Since the unit cube is at origin (min: (-0.5,-0.5,-0.5) and max: (0.5,0.5,0.5))
	//adding (0.5,0.5,0.5) to the unit cube object space position gives us values from (0,0,0) to 
	//(1,1,1)
	vUV = inPosition + vec3(0.5);
}
";
        private const string defaultFrag = @"#version 330 core

layout(location = 0) out vec4 outColor;	//fragment shader output

smooth in vec3 vUV;				//3D texture coordinates form vertex shader 
								//interpolated by rasterizer

//uniforms
uniform sampler3D	volume;		//volume dataset
uniform vec3		camPos;		//camera position
uniform vec3		step_size;	//ray step size 

//constants
const int MAX_SAMPLES = 300;	//total samples for each ray march step
const vec3 texMin = vec3(0);	//minimum texture access coordinate
const vec3 texMax = vec3(1);	//maximum texture access coordinate

void main()
{ 
	//get the 3D texture coordinates for lookup into the volume dataset
	vec3 dataPos = vUV;

	//Getting the ray marching direction:
	//get the object space position by subracting 0.5 from the
	//3D texture coordinates. Then subtraact it from camera position
	//and normalize to get the ray marching direction
	vec3 geomDir = normalize((vUV-vec3(0.5)) - camPos); 

	//multiply the raymarching direction with the step size to get the
	//sub-step size we need to take at each raymarching step
	vec3 dirStep = geomDir * step_size; 
	 
	//flag to indicate if the raymarch loop should terminate
	bool stop = false; 

    bool isDiscard = true;

	//for all samples along the ray
	for (int i = 0; i < MAX_SAMPLES; i++) {
		// advance ray by dirstep
		dataPos = dataPos + dirStep;
		
		
		//The two constants texMin and texMax have a value of vec3(-1,-1,-1)
		//and vec3(1,1,1) respectively. To determine if the data value is 
		//outside the volume data, we use the sign function. The sign function 
		//return -1 if the value is less than 0, 0 if the value is equal to 0 
		//and 1 if value is greater than 0. Hence, the sign function for the 
		//calculation (sign(dataPos-texMin) and sign (texMax-dataPos)) will 
		//give us vec3(1,1,1) at the possible minimum and maximum position. 
		//When we do a dot product between two vec3(1,1,1) we get the answer 3. 
		//So to be within the dataset limits, the dot product will return a 
		//value less than 3. If it is greater than 3, we are already out of 
		//the volume dataset
		stop = dot(sign(dataPos-texMin),sign(texMax-dataPos)) < 3.0;

		//if the stopping condition is true we brek out of the ray marching loop
		if (stop) 
			break;
		
		// data fetching from the red channel of volume texture
		float sample = texture(volume, dataPos).r;	
		
		//Opacity calculation using compositing:
		//here we use front to back compositing scheme whereby the current sample
		//value is multiplied to the currently accumulated alpha and then this product
		//is subtracted from the sample value to get the alpha from the previous steps.
		//Next, this alpha is multiplied with the current sample colour and accumulated
		//to the composited colour. The alpha value from the previous steps is then 
		//accumulated to the composited colour alpha.
		float prev_alpha = sample - (sample * outColor.a);
		outColor.rgb = prev_alpha * vec3(sample) + outColor.rgb; 
		outColor.a += prev_alpha; 
        isDiscard = false;
			
		//early ray termination
		//if the currently composited colour alpha is already fully saturated
		//we terminated the loop
		if( outColor.a>0.99)
			break;
	} 
    
    if (isDiscard)
    {
         discard;
    }
}
";

    }
}
