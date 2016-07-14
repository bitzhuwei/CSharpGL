#version 150 core

uniform vec4 color = vec4(0, 1, 0, 1);

out vec4 out_Color;

void main(void) {
	out_Color = color;
}