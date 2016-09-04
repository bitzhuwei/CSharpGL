#version 150 core

in vec3 in_Positions;
uniform mat4 projection;
uniform mat4 view;
uniform float model;
void main()
{
	gl_Position = projection * view * model * vec4(in_Positions, 1.0f);
}
