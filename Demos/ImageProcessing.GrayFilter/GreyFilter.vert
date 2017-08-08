#version 150

uniform mat4 mvpMatrix;

in vec3 a_vertex;
in vec2 a_texCoord;

out vec2 v_texCoord;

void main(void)
{
	v_texCoord = a_texCoord;

	gl_Position = mvpMatrix * vec4(a_vertex, 1.0f);
}