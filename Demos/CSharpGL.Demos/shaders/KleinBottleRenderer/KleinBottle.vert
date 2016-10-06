#version 150 core

in vec3 in_Position;
in float in_TexCoord;

out float passTexCoord;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

	passTexCoord = in_TexCoord;
}
