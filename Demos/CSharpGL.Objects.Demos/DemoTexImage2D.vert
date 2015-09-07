#version 150 core

in vec3 in_Position;
in vec2 in_uv;
out vec2 pass_uv;

uniform mat4 MVP;

void main(void) 
{
	gl_Position = MVP * vec4(in_Position, 1.0);

	pass_uv = in_uv;
}