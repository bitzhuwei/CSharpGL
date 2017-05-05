#version 150 core

out vec4 out_Color;

uniform vec3 color = vec3(1, 1, 1);

void main(void) {
	out_Color = vec4(color, 1.0f);
}
