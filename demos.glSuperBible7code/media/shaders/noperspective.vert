#version 410 core

out VS_OUT
{
    vec2 tc;
    noperspective vec2 tc_np;
} vs_out;

uniform mat4 mvp;

void main(void)
{
     vec4 vertices[] = vec4[](vec4(-0.5, -0.5, 0.0, 1.0),
                                   vec4( 0.5, -0.5, 0.0, 1.0),
                                   vec4(-0.5,  0.5, 0.0, 1.0),
                                   vec4( 0.5,  0.5, 0.0, 1.0));

    vec2 tc = (vertices[gl_VertexID].xy + vec2(0.5));
    vs_out.tc = tc;
    vs_out.tc_np = tc;
    gl_Position = mvp * vertices[gl_VertexID];
}