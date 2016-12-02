#version 330 core

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;
uniform mat3 normalMatrix;

in vec3 inNormal;
in vec3 inColor;
in vec3 inPosition;

out vec3 passNormal;
out vec3 passColor;
out vec3 passPosition;

void main()
{
	passNormal = normalize(normalMatrix * inNormal);
	passColor = inColor;
	passPosition = vec3(model * vec4(inPosition, 1.0));
	gl_Position = projection * view * model * vec4(inPosition, 1.0);
}
