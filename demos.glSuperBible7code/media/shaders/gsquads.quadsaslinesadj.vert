#version 410 core

uniform mat4 mvp;
uniform int vid_offset = 0;

out VS_OUT
{
    vec4 color;
} vs_out;

void main(void)
{
    const vec4 vertices[] = vec4[](vec4(-0.5, -0.5, 0.0, 1.0),
                                   vec4( 0.5, -0.5, 0.0, 1.0),
                                   vec4( 0.5,  0.5, 0.0, 1.0),
                                   vec4(-0.5,  0.5, 0.0, 1.0));

    const vec4 colors[] = vec4[](vec4(0.0, 0.0, 0.0, 1.0),
                                 vec4(0.0, 0.0, 0.0, 1.0),
                                 vec4(0.0, 0.0, 0.0, 1.0),
                                 vec4(1.0, 1.0, 1.0, 1.0));

    gl_Position = mvp * vertices[(gl_VertexID + vid_offset) % 4];
    vs_out.color = colors[gl_VertexID]; // colors[(gl_VertexID + vid_offset) % 4];
}
