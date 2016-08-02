#version 150 core

in vec3 in_Position;
in float in_TexCoord;

out float passTexCoord;

uniform mat4 mvp;

void main(void) 
{
	gl_Position = mvp * vec4(in_Position, 1.0);

	passTexCoord = in_TexCoord;
}