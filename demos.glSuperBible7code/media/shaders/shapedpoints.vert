#version 410 core

flat out int shape;

void main(void)
{
    const vec4[4] position = vec4[4](vec4(-0.4, -0.4, 0.5, 1.0),
                                     vec4( 0.4, -0.4, 0.5, 1.0),
                                     vec4(-0.4,  0.4, 0.5, 1.0),
                                     vec4( 0.4,  0.4, 0.5, 1.0));
    gl_Position = position[gl_VertexID];
    shape = gl_VertexID;
}