#version 410 core

layout (triangles) in;
layout (triangle_strip, max_vertices = 11) out;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

uniform float normalLength = 0.5f;

in VS_GS_VERTEX
{
    vec3 normal;
} vertex_in[];

out GS_FS_VERTEX
{
    vec3 color;
} vertex_out;

void main(void)
{
	int i;
	
	for (i = 0; i < gl_in.length(); i++) {
        vertex_out.color = vertex_in[i].normal;
        vec4 position = gl_in[i].gl_Position;
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
		EmitVertex();
    }
	EndPrimitive();

	for (i = 0; i < gl_in.length(); i++) {
		vertex_out.color = vec3(1, 1, 1);

		vec4 position = gl_in[i].gl_Position;
		vec4 target = position + vertex_in[i].normal * normalLength;
		{
			vec4 v0 = position;
			gl_Position = projectionMatrix * viewMatrix * (modelMatrix * v0);
			EmitVertex();

			vec4 v1 = target;
			if (target.x > position.x) { v1.x += normalLength / 30.0f; }
			else { v1.x -= normalLength / 10.0f; }
			gl_Position = projectionMatrix * viewMatrix * (modelMatrix * v1);
			EmitVertex();

			vec4 v2 = position;
			gl_Position = projectionMatrix * viewMatrix * (modelMatrix * v2);
			EmitVertex();

			vec4 v3 = target;
			if (target.y > position.y) { v3.y += normalLength / 30.0f; }
			else { v3.y -= normalLength / 10.0f; }
			gl_Position = projectionMatrix * viewMatrix * (modelMatrix * v3);
			EmitVertex();
			
			vec4 v4 = position;
			gl_Position = projectionMatrix * viewMatrix * (modelMatrix * v4);
			EmitVertex();

			vec4 v5 = target;
			if (target.z > position.z) { v5.z += normalLength / 30.0f; }
			else { v5.z -= normalLength / 10.0f; }
			gl_Position = projectionMatrix * viewMatrix * (modelMatrix * v5);
			EmitVertex();

			vec4 v6 = position;
			gl_Position = projectionMatrix * viewMatrix * (modelMatrix * v6);
			EmitVertex();

			vec4 v7 = target;
			if (target.x > position.x) { v7.x += normalLength / 30.0f; }
			else { v7.x -= normalLength / 10.0f; }
			gl_Position = projectionMatrix * viewMatrix * (modelMatrix * v7);
			EmitVertex();

		}
		
		EndPrimitive();
    }
}