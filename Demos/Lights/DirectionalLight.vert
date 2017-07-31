#version 330 core

in vec3 vPosition; / per-vertex position
in vec3 vNormal; // per-vertex normal

uniform mat4 MVP; // combined model view projection matrix
uniform mat3 N; // normal matrix

smooth out vec3 vEyeSpaceNormal; // normal in eye space

void main()
{
	vEyeSpacePosition = (MV * vec4(vPosition, 1)).xyz;

	vEyeSpaceNormal = N * vNormal;

	gl_Position = MVP * vec4(vPosition, 1);
}