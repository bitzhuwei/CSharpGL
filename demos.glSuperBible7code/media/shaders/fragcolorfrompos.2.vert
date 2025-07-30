#version 420 core

out vec4 vs_color;
void main(void)
{
     vec4 vertices[] = vec4[](vec4( 0.25, -0.25, 0.5, 1.0),
                                   vec4(-0.25, -0.25, 0.5, 1.0),
                                   vec4( 0.25,  0.25, 0.5, 1.0));
     vec4 colors[] = vec4[](vec4(1.0, 0.0, 0.0, 1.0),
                                 vec4(0.0, 1.0, 0.0, 1.0),
                                 vec4(0.0, 0.0, 1.0, 1.0));

    gl_Position = vertices[gl_VertexID];
    vs_color = colors[gl_VertexID];
}