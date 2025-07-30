#version 420 core

void main(void)
{
     vec4 vertices[] = vec4[](vec4(-1.0 * 0.9, -1.0 * 0.9, 0.5, 1.0),
                              vec4( 1.0 * 0.9, -1.0 * 0.9, 0.5, 1.0),
                              vec4(-1.0 * 0.9,  1.0 * 0.9, 0.5, 1.0),
                              vec4( 1.0 * 0.9,  1.0 * 0.9, 0.5, 1.0));

    gl_Position = vertices[gl_VertexID];
}