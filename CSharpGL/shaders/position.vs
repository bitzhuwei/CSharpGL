#version 330 core

layout(location = 0) in vec3 inPosition;

void main(void) {
	gl_Position = vec4(inPosition, 1.0);
}
