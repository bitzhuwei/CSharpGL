#version 150 core

in float passCoord;

uniform vec4 lineColor = vec4(1, 1, 1, 1);

out vec4 out_Color;

void main(void) 
{
	out_Color = lineColor;
}
