#version 150 core

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;

in vec3 inPosition;
in vec3 inColor;

out vec3 passColor;

void main()
{
	gl_Position = projection * view * model * vec4(inPosition, 1.0);

	passColor = inColor;
}
