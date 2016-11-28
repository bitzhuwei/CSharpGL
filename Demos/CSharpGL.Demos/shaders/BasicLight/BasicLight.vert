#version 330 core

uniform mat4 mvpMatrix;

in vec3 inPosition;
in vec3 inColor;

out vec3 passColor;

void main()
{
	passColor = inColor;
	gl_Position = mvpMatrix * vec4(inPosition, 1.0);
}
