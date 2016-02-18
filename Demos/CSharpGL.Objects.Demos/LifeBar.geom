#version 150 core

layout (triangles) in;
layout (triangle_strip, max_vertices = 27) out;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

void main(void)
{
    int i;
    for (i = 0; i < gl_in.length(); i++)
    {
        vec4 position = gl_in[i].gl_Position;
        gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
        EmitVertex();
    }
    EndPrimitive();
}

