#version 150 core

in vec3 in_Position;
in vec3 in_Brightness;

uniform mat4 mvp;

out vec3 passBrightness;

void main(void) 
{
	gl_Position = mvp * vec4(in_Position, 1.0);

	passBrightness = in_Brightness;
}