#version 150 core

in vec3  in_Position;
out vec2 pass_position;
out float pass_pointSize;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);
	//gl_PointSize = 40;//in_radius;
}