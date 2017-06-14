#version 150 core

in vec3 in_Position;
in vec2 in_TexCoord;
uniform mat4 mvp;

out vec2 passUV;

void main(void)
{
	gl_Position = mvp * vec4(in_Position, 1.0f);

	passUV = in_TexCoord;
}
