#version 150 core

in vec3 in_Position;
//in vec3 in_Normal;
in vec3 in_Color;  
out vec4 pass_Color;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
//uniform vec3 lightPosition;

void main(void) 
{
	vec4 position = vec4(in_Position, 1.0);
	vec4 ePosition = viewMatrix * modelMatrix * position;

	pass_Color = vec4(in_Color, 1.0);

	gl_Position = projectionMatrix * ePosition;
}