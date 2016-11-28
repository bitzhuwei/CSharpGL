#version 330 core

uniform vec3 ambientLight;

in vec3 passColor;

out vec4 outColor;

void main()
{
	outColor = vec4(min(passColor * ambientLight, vec3(1.0)), 1.0);
}
