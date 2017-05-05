#version 150 core

in vec3 in_Position;

void main(void) {
	gl_Position = vec4(in_Position, 1.0);
}
