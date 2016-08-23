#version 150 core

in vec3  in_Position;
// only 'u' is stored and passed as 'v' is always the same value.
in float in_uv;
out float pass_uv;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

	pass_uv = in_uv;
}