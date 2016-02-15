#version 410 core

layout (triangles) in;
layout (triangle_strip, max_vertices = 9) out;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

uniform int fur_layers = 1;
uniform float fur_depth = 0.2;

in VS_GS_VERTEX
{
    vec3 normal;
    //vec2 tex_coord;
} vertex_in[];

out GS_FS_VERTEX
{
    vec3 normal;
    //vec2 tex_coord;
    //flat float fur_strength;
} vertex_out;

void main(void)
{
	int odd = 0;
	int i;

	
	for (i = 0; i < gl_in.length(); i++) {
        vec3 n = vertex_in[i].normal;
        vertex_out.normal = n;
        vec4 position = gl_in[i].gl_Position;// + vec4(n, 0.0);
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
		EmitVertex();
    }
	EndPrimitive();

	for (i = 0; i < gl_in.length(); i++) {
        vec3 n = vertex_in[i].normal;
        vertex_out.normal = n;
        vec4 position = gl_in[i].gl_Position;// + vec4(n, 0.0);
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
		EmitVertex();
		position = position + vec4(n, 0.0) * fur_depth;
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
		EmitVertex();
		position = position + vec4(n, 0.0) * fur_depth + vec4(0.01f, 0.01f, 0.01f, 0);
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
		EmitVertex();
		EndPrimitive();
    }
}