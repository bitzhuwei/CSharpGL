#version 330 core

// vert and frag shader share a block of uniforms named 'Uniforms'
struct Uniforms {
    mat4 projection;
    mat4 view;
	mat4 model;
};

uniform Uniforms transformMatrix;

in vec3 vPos;
in vec3 vColor;
out vec3 fColor;

void main(void) {
 
	gl_Position = transformMatrix.projection * transformMatrix.view * transformMatrix.model * vec4(vPos, 1.0);
	
	fColor = vColor;
}
