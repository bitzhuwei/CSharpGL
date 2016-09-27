#version 430 core

in vec3 fColor;

out vec4 out_Color;

void main(void) {
	out_Color = vec4(fColor, 1.0f);
}
