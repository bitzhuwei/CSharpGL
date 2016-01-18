#version 150 core

in vec3 in_Position;
//in vec3 in_Color;  
in vec3 in_Normal;  
out vec4 pass_Color;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) 
{
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

	pass_Color = vec4(in_Normal, 1.0);
}