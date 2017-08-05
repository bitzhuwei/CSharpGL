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
        /// update particles.
        /// </summary>
        private const string udpateVert = @"#version 330 core
precision highp float;

#extension EXT_gpu_shader4 : require

layout( location = 0 )  in vec4 position;           //xyz pos, w speed
layout( location = 1 )  in vec4 prev_position;      //xyz prevPos, w life
layout( location = 2 )  in vec4 direction;			//xyz direction, w 0
 
uniform mat4 MVP; //combine modelview projection matrix
 
uniform float time; //current time
   
//constants
const float PI = 3.14159;
const float TWO_PI = 2*PI;
const float PI_BY_2 = PI*0.5;
const float PI_BY_4 = PI_BY_2*0.5;
 
//shader outputs
out vec4 out_position;
out	vec4 out_prev_position;
out vec4 out_direction;

const float DAMPING_COEFFICIENT =  0.9995;			//velocity damping coefficient
const vec3 emitterForce = vec3(0.0f,-0.001f, 0.0f);	//the default force direction
const vec4 collidor = vec4(0,1,0,0);				//the colliding plane
const vec3 emitterPos = vec3(0);					//current emitter position

//emitter orientation parameters
float emitterYaw = (0.0f);
float emitterPitch	= PI_BY_2;
float emitterSpeed = 0.05f;
int	  emitterLife = 60;

//adjustment for each individual particle
float emitterYawVar	= TWO_PI;
float emitterPitchVar = PI_BY_4;
float emitterSpeedVar = 0.01f;
int   emitterLifeVar = 15;

//for pseudo random number
const float UINT_MAX = 4294967295.0;

//hashing function for pseudo random number
uint randhash(uint seed)
{
    uint i=(seed^12345391u)*2654435769u;
    i^=(i<<6u)^(i>>26u);
    i*=2654435769u;
    i+=(i<<5u)^(i>>12u);
    return i;
}
//returns a pseudo random number between 0 and 1
float randhashf(uint seed, float b)
{
    return float(b * randhash(seed)) / UINT_MAX;
}

//given a pitch and yaw value, this function returns a direction
//vector on the unit sphere
void RotationToDirection(float pitch, float yaw, out vec3 direction)
{
	direction.x = -sin(yaw) * cos(pitch);
	direction.y = sin(pitch);
	direction.z = cos(pitch) * cos(yaw);
}

 
void main() 
{    
	//store current and previous position of particle
	vec3 prevPos = prev_position.xyz;
	int life = int(prev_position.w);
	vec3 pos  = position.xyz;

	//also store the current speed and direction of particle
	float speed = position.w;
	vec3 dir = direction.xyz; 

	//if life is > 0, we can simulate the particle
	if(life > 0) {
		prevPos = pos;
		pos += dir*speed; 
		if(dot(pos+emitterPos, collidor.xyz)+ collidor.w <0) {			 
			dir = reflect(dir, collidor.xyz);
			speed *= DAMPING_COEFFICIENT;
		}  
		dir += emitterForce;
		life--;
	
	//otherwise we spawn a new particle using the (particle id + current time) as seed
	//we assign this particle a random life using the emitters life variation as limit
	//similarly for other properties of particle like yaw, pitch, speed etc
	}  else { 
		uint seed =   uint(time + gl_VertexID); 
		life = emitterLife + int(randhashf(seed++, emitterLifeVar));    
        float yaw = emitterYaw + (randhashf(seed++, emitterYawVar ));
		float pitch = emitterPitch + randhashf(seed++, emitterPitchVar);
		RotationToDirection(pitch, yaw, dir);		 
		float nspeed = emitterSpeed + (randhashf(seed++, emitterSpeedVar ));
		dir *= nspeed;  
		pos = emitterPos;
		prevPos = emitterPos; 
		speed = 1;
	}  

	//we then store the outputs and write to gl_Position 
	out_position = vec4(pos, speed);	
	out_prev_position = vec4(prevPos, life);		
	out_direction = vec4(dir, 0);
	gl_Position = MVP*vec4(pos, 1); 
}
";

    }
}
