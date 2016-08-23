#version 150 core

in vec3 in_Position;
in vec3 in_Color;

out vec3 passColor;

uniform mat4 mvp;

void main(void) 
{
	gl_Position = mvp * vec4(in_Position, 1.0);

	passColor = in_Color;
}