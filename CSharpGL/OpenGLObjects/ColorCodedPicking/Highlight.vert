#version 150 core

in vec3 in_Position;

uniform mat4 MVP;

void main(void) {
	gl_Position = MVP * vec4(in_Position, 1.0);
}