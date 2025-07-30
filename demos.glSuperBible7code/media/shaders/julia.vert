// Julia set renderer - Vertex Shader
// Graham Sellers
// OpenGL SuperBible
#version 150 core

// Zoom factor
uniform float zoom;

// Offset vector
uniform vec2 offset;

out vec2 initial_z;

void main(void)
{
     vec4 vertices[4] = vec4[4](vec4(-1.0 * 0.9, -1.0 * 0.9, 0.5, 1.0),
                                vec4( 1.0 * 0.9, -1.0 * 0.9, 0.5, 1.0),
                                vec4( 1.0 * 0.9,  1.0 * 0.9, 0.5, 1.0),
                                vec4(-1.0 * 0.9,  1.0 * 0.9, 0.5, 1.0));
    initial_z = (vertices[gl_VertexID].xy * zoom) + offset;
    gl_Position = vertices[gl_VertexID];
}