#version 150 core

in vec3 in_Position;

uniform mat4 MVP;
uniform float pointSize;

void main(void) {
	gl_Position = MVP * vec4(in_Position, 1.0);
	gl_PointSize = pointSize;
}
