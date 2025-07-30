#version 410 core

uniform vec2 offset;

out vec2 tex_coord;

void main(void)
{
     vec4 vertices[] = vec4[](vec4(-0.45, -0.45, 0.5, 1.0),
                                   vec4( 0.45, -0.45, 0.5, 1.0),
                                   vec4(-0.45,  0.45, 0.5, 1.0),
                                   vec4( 0.45,  0.45, 0.5, 1.0));

    gl_Position = vertices[gl_VertexID] + vec4(offset, 0.0, 0.0);
    tex_coord = vertices[gl_VertexID].xy * 3.0 + vec2(0.45 * 3);
}