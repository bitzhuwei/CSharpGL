#version 330 core

// vert and frag shader share a block of uniforms named 'Uniforms'
uniform float projectionMatrix[16];
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

in vec3 vPos;
in vec3 vColor;
out vec3 fColor;

void main(void) {

    mat4 projection = mat4(
		vec4(projectionMatrix[0], projectionMatrix[1], projectionMatrix[2], projectionMatrix[3]),
		vec4(projectionMatrix[4], projectionMatrix[5], projectionMatrix[6], projectionMatrix[7]),
		vec4(projectionMatrix[8], projectionMatrix[9], projectionMatrix[10], projectionMatrix[11]),
		vec4(projectionMatrix[12], projectionMatrix[13], projectionMatrix[14], projectionMatrix[15]));
	gl_Position = projection * viewMatrix * modelMatrix * vec4(vPos, 1.0);
	
	fColor = vColor;
}
