#version 150 core

in vec3 passColor;
out vec4 out_Color;

void main(void) {
	out_Color = vec4(passColor, 1.0f);
}
