#version 150 core

uniform vec4 highlightColor;

out vec4 out_Color;

void main(void) {
	out_Color = highlightColor;
}