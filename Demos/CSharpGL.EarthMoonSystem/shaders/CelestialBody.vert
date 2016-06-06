#version 150 core

in vec3 inPosition;
in vec2 inUV;  

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

out vec2 passUV;

void main(void)
{
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);

	passUV = inUV;
}
