using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace VolumeRendering.ISOSurface
{
    partial class RaycastingNode
    {
        private const string isourfaceVert = @"#version 330 core
  
layout(location = 0) in vec3 inPosition; //object space vertex position

//uniform
uniform mat4 mvpMat;   //combined modelview projection matrix

smooth out vec3 passUV; //3D texture coordinates for texture lookup in the fragment shader

void main()
{  
	//get the clipspace position 
	gl_Position = mvpMat*vec4(inPosition.xyz,1);

	//get the 3D texture coordinates by adding (0.5,0.5,0.5) to the object space 
	//vertex position. Since the unit cube is at origin (min: (-0.5,-0.5,-0.5) and max: (0.5,0.5,0.5))
	//adding (0.5,0.5,0.5) to the unit cube object space position gives us values from (0,0,0) to 
	//(1,1,1)
	passUV = inPosition + vec3(0.5);
}
";
        private const string isosurfaceFrag = @"#version 330 core

layout(location = 0) out vec4 outColor;	//fragment shader output

smooth in vec3 passUV;				//3D texture coordinates form vertex shader 
								//interpolated by rasterizer

//uniforms
uniform sampler3D	volume;			//volume dataset
uniform vec3		camPos;			//camera position
uniform vec3		step_size;		//ray step size 

//constants
const int maxSampleCount = 300;		//total samples for each ray march step
const vec3 texMin = vec3(0);		//minimum texture access coordinate
const vec3 texMax = vec3(1);		//maximum texture access coordinate
const float DELTA = 0.01;			//the step size for gradient calculation
const float isoValue = 40/255.0;	//the isovalue for iso-surface detection

//function to give a more accurate position of where the given iso-value (iso) is found
//given the initial minimum limit (left) and maximum limit (right)
vec3 Bisection(vec3 left, vec3 right , float iso)
{ 
	//loop 4 times
	for(int i=0;i<4;i++)
	{ 
		//get the mid value between the left and right limit
		vec3 midpoint = (right + left) * 0.5;
		//sample the texture at the middle point
		float cM = texture(volume, midpoint).x ;
		//check if the value at the middle point is less than the given iso-value
		if(cM < iso)
			//if so change the left limit to the new middle point
			left = midpoint;
		else
			//otherwise change the right limit to the new middle point
			right = midpoint; 
	}
	//finally return the middle point between the left and right limit
	return vec3(right + left) * 0.5;
}

//function to calculate the gradient at the given location in the volume dataset
//The function user center finite difference approximation to estimate the 
//gradient
vec3 GetGradient(vec3 uvw) 
{
	vec3 s1, s2;  

	//Using center finite difference 
	s1.x = texture(volume, uvw-vec3(DELTA,0.0,0.0)).x ;
	s2.x = texture(volume, uvw+vec3(DELTA,0.0,0.0)).x ;

	s1.y = texture(volume, uvw-vec3(0.0,DELTA,0.0)).x ;
	s2.y = texture(volume, uvw+vec3(0.0,DELTA,0.0)).x ;

	s1.z = texture(volume, uvw-vec3(0.0,0.0,DELTA)).x ;
	s2.z = texture(volume, uvw+vec3(0.0,0.0,DELTA)).x ;
	 
	return normalize((s1-s2)/2.0); 
}

//function to estimate the PhongLighting component given the light vector (L),
//the normal (N), the view vector (V), the specular power (specPower) and the
//given diffuse colour (diffuseColor). The diffuse component is first calculated
//Then, the half way vector is computed to obtain the specular component. Finally
//the diffuse and specular contributions are added together
vec4 PhongLighting(vec3 L, vec3 N, vec3 V, float specPower, vec3 diffuseColor)
{
	float diffuse = max(dot(L,N),0.0);
	vec3 halfVec = normalize(L+V);
	float specular = pow(max(0.00001,dot(halfVec,N)),specPower);	
	return vec4((diffuse*diffuseColor + specular),1.0);
}

void main()
{ 
	//get the 3D texture coordinates for lookup into the volume dataset
	vec3 dataPos = passUV;
		
	//Gettting the ray marching direction:
	//get the object space position by subracting 0.5 from the
	//3D texture coordinates. Then subtraact it from camera position
	//and normalize to get the ray marching direction
	vec3 geomDir = normalize((passUV-vec3(0.5)) - camPos); 

	//multiply the raymarching direction with the step size to get the
	//sub-step size we need to take at each raymarching step
	vec3 dirStep = geomDir * step_size; 
	
	//flag to indicate if the raymarch loop should terminate
	bool stop = false; 
	
    bool isDiscard = true;

	//for all samples along the ray
	for (int i = 0; i < maxSampleCount; i++) {
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
        {
            break;
        }
		
		// data fetching from the red channel of volume texture
		float sample = texture(volume, dataPos).r;			//current sample
		float sample2 = texture(volume, dataPos+dirStep).r;	//next sample

		//In case of iso-surface rendering, we do not use compositing. 
		//Instead, we find the zero crossing of the volume dataset iso function 
		//by sampling two consecutive samples. 
		if( (sample -isoValue) < 0  && (sample2-isoValue) >= 0.0)  {
			//If there is a zero crossing, we refine the detected iso-surface 
			//location by using bisection based refinement.
			vec3 xN = dataPos;
			vec3 xF = dataPos+dirStep;	
			vec3 tc = Bisection(xN, xF, isoValue);	
	
			//This returns the first hit surface
			//outColor = make_float4(xN,1);
          	
			//To get the shaded iso-surface, we first estimate the normal
			//at the refined position
			vec3 N = GetGradient(tc);					

			//The view vector is simply opposite to the ray marching 
			//direction
			vec3 V = -geomDir;

			//We keep the view vector as the light vector to give us a head 
			//light
			vec3 L =  V;

			//Finally, we call PhongLighing function to get the final colour
			//with diffuse and specular components. Try changing this call to this
			//outColor =  PhongLighting(L,N,V,250,  tc); to get a multi colour
			//iso-surface
			outColor =  PhongLighting(L,N,V,250, vec3(0.5));	
            isDiscard = false;
			break;
		} 
	} 
    
    if (isDiscard)
    {
        discard;
    }
}
";

    }
}
