#version 330 core

uniform mat4 mvpMatrix;
uniform mat3 normalMatrix;

in vec3 inPosition;
in vec3 inColor;
in vec3 inNormal;

out vec3 passNormal;
out vec3 passColor;

void main()
{
	passNormal = normalize(normalMatrix * inNormal);
	passColor = inColor;
	gl_Position = mvpMatrix * vec4(inPosition, 1.0);
}
