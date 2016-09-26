#version 330 core

uniform mat4 projectionMatrix;
uniform float viewMatrix[16];// test uniform array variable.
uniform mat4 modelMatrix;

in vec3 vPos;
in vec3 vColor;
out vec3 fColor;

void main(void) {

    mat4 view = mat4(
		vec4(viewMatrix[0], viewMatrix[1], viewMatrix[2], viewMatrix[3]),
		vec4(viewMatrix[4], viewMatrix[5], viewMatrix[6], viewMatrix[7]),
		vec4(viewMatrix[8], viewMatrix[9], viewMatrix[10], viewMatrix[11]),
		vec4(viewMatrix[12], viewMatrix[13], viewMatrix[14], viewMatrix[15]));
	gl_Position = projectionMatrix * view * modelMatrix * vec4(vPos, 1.0);
	
	fColor = vColor;
}
