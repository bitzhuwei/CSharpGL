#version 150 core

in vec3 in_Position;
in vec3 in_Color;
in vec3 passColor;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);
	passColor = in_Color;
}
