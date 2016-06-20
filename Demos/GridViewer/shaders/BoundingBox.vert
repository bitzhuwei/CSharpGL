#version 150 core

in vec3 in_Position;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) 
{
	gl_Position = MVP * vec4(in_Position, 1.0);
}