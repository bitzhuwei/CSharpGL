#version 150 core

in vec3 in_Position;
in vec2 in_UV;  
out vec2 pass_UV;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) 
{
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

	pass_UV = in_UV;
}
