#version 150 core

in vec3 in_Position;
in vec3 in_Color;

out vec3 passColor;

void main(void) {
	gl_Position = vec4(in_Position, 1.0);

	passColor = in_Color;
}
