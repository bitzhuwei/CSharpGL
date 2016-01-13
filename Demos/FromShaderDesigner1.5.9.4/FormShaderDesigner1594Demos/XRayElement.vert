// Application to vertex shader
varying vec3 N;
varying vec3 I;
varying vec4 Cs;

in vec3 in_Position;
in vec3 

uniform mat4 modelMat;
uniform mat4 viewMat;
uniform mat4 projectionMat;

void main()
{
	vec4 P = viewMat * modelMat * in_Position;
	
	I  = P.xyz - vec3 (0);
	
	N  = gl_NormalMatrix * gl_Normal;
	
	Cs = gl_Color;
	
	gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;	
} 
