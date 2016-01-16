// Application to vertex shader
#version 150 core
 
in vec3 in_Position;
in vec3 in_Normal;
in vec3 in_Color;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

out vec3 N;
out vec3 I;
out vec4 Cs;

void main()
{
	vec4 P = viewMatrix * modelMatrix * vec4(in_Position, 1.0);
	
	I  = P.xyz - vec3 (0);
	
	N  = vec3(viewMatrix * modelMatrix * vec4(in_Normal, 1.0));
	
	Cs = vec4(in_Color, 1.0);
	
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);	
} 
