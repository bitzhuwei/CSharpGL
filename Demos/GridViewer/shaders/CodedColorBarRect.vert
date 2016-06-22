#version 150 core

in vec2 in_Position;
in float in_Coord;

out float passCoord;

uniform mat4 mvp;

void main(void) 
{
	gl_Position = mvp * vec4(in_Position, 0.0, 1.0);
	passCoord = in_Coord;
}