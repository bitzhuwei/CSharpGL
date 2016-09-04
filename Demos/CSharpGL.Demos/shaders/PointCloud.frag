#version 150 core

out vec4 outColor;

uniform vec3 PointColor = vec3(1, 0, 1);
void main(void)
{
	outColor = vec4(PointColor, 1);
}

