#version 150 core

in vec3 in_Position;
in vec3 in_Color;

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;

out vec3 passColor;

void main(void) {
	gl_Position = projection * view * model * vec4(in_Position, 1.0);
	passColor = in_Color;
}
