#version 430 core


layout (std140, binding = 0) buffer PositionBuffer {
    vec4 positions[];
};
layout (std140, binding = 1) buffer ColorBuffer {
	vec4 colors[];
};

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

out vec3 fColor;

void main(void) {

	vec3 vPos = positions[gl_VertexID].xyz;
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(vPos, 1.0);
	
	fColor = colors[gl_VertexID].xyz; 
}
