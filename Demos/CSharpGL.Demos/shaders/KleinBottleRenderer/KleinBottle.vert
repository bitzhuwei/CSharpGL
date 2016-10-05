#version 150 core

in vec3 in_Position;
in vec2 in_TexCoord;

out vec2 passTexCoord;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

	passTexCoord = in_TexCoord;
}
