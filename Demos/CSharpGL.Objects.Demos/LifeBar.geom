#version 150 core

layout (points) in;
layout (triangle_strip, max_vertices = 27) out;

out GS_FS_VERTEX
{
    vec3 color;
} vertex_out;

uniform float length = 1;
uniform float width = 1;
uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

void main(void)
{
    int i;
    vec4 position;
    for (i = 0; i < gl_in.length(); i++)
    {
        position = gl_in[i].gl_Position;
        position.x = length / 2 + position.x;
        position.y = width / 2 + position.y;
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
        EmitVertex();
        position = gl_in[i].gl_Position;
        position.x = length / 2 + position.x;
        position.y = -width / 2 + position.y;
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
        EmitVertex();
        position = gl_in[i].gl_Position;
        position.x = -length / 2 + position.x;
        position.y = width / 2 + position.y;
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
        EmitVertex();
        position = gl_in[i].gl_Position;
        position.x = -length / 2 + position.x;
        position.y = -width / 2 + position.y;
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
        EmitVertex();
    }
    EndPrimitive();
}

