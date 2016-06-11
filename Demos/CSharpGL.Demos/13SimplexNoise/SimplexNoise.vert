#version 150 core

in vec3 in_Position;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;
uniform float granularity = 4.0f;

out vec3 v_texCoord3D;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

	v_texCoord3D = in_Position * granularity;
}
