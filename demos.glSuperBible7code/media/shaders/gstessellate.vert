// Vertex Shader
// OpenGL SuperBible
#version 410 core

// Incoming per vertex... position and normal
in vec4 vVertex;

void main(void)
{
    gl_Position = vVertex;
}