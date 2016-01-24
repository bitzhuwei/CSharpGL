#version 150 core

in vec3 in_Position;
in vec3 in_Color;  
out vec4 pass_Color;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

void main(void) 
{
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);// setup vertex's position

	pass_Color = vec4(in_Color, 1.0);// pass color to fragment shader
}