#version 330 core

// vert and frag shader share a block of uniforms named 'Uniforms'
uniform Uniforms {
    vec3 translation;
	float scale;
};

in vec3 vPos;
in vec3 vColor;
out vec3 fColor;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
//uniform mat4 modelMatrix;

void main(void) {
 
    mat4 modelMatrix = mat4(1.0f);
	modelMatrix[3].xyz = translation;
	modelMatrix[0].x = scale;
	modelMatrix[1].y = scale;
	modelMatrix[2].z = scale;
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(vPos, 1.0);

	fColor = vColor;
}
