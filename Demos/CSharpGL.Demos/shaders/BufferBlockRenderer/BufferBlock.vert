#version 330 core

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

buffer VertexData {
    vec3 position;
	//vec3 normal;
};

//out vec3 fColor;

void main(void) {

	vec3 vPos = position[gl_VertexID]; 
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(vPos, 1.0);
	
	//fColor = normal[gl_VertexID]; 
}
