#version 150 core

in vec3 in_Position;
flat out vec4 pass_Color; // glShadeMode(GL_FLAT); in legacy opengl.
uniform mat4 MVP;
uniform int pickingBaseId; // how many vertices have been coded so far?

void main(void) {
	gl_Position = MVP * vec4(in_Position, 1.0);

	int objectID = pickingBaseId + gl_VertexID;
	pass_Color = vec4(
		float(objectID & 0xFF) / 255.0, 
		float((objectID >> 8) & 0xFF) / 255.0, 
		float((objectID >> 16) & 0xFF) / 255.0, 
		float((objectID >> 24) & 0xFF) / 255.0);
}