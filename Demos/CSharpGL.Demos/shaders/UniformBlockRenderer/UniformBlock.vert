#version 330 core

// vert and frag shader share a block of uniforms named 'Uniforms'
uniform Uniforms {
	mat4 modelMatrix;
};

in vec3 vPos;
in vec3 vColor;
out vec3 fColor;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
//uniform mat4 modelMatrix;

void main(void) {
 
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(vPos, 1.0);
	
	fColor = vColor;
}
