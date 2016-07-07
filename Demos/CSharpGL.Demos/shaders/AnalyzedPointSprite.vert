#version 150 core

uniform mat4 mvp;
uniform float factor = 100.0f;

in vec3 position;

void main(void)
{
	vec4 pos = mvp * vec4(position, 1.0f);
	gl_PointSize = (1.0 - pos.z / pos.w) * factor;
	gl_Position = pos;
}
