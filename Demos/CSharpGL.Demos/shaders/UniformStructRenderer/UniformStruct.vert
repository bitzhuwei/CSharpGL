#version 330 core

struct Uniforms {
    mat4 projection;
    mat4 view;
	mat4 model;
};

uniform Uniforms transform;

in vec3 vPos;
in vec3 vColor;
out vec3 fColor;

void main(void) {
 
	gl_Position = transform.projection * transform.view * transform.model * vec4(vPos, 1.0);
	
	fColor = vColor;
}
