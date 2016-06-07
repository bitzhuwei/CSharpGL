#version 150 core

in vec2 inPosition;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void)
{
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition.x, 0.0, inPosition.y, 1.0);
}
