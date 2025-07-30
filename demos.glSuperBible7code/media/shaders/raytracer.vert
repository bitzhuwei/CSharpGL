#version 420

void main(void)
{
    vec4 vertices[4] = vec4[4](vec4(-1.0, -1.0, 0.5, 1.0),
                               vec4( 1.0, -1.0, 0.5, 1.0),
                               vec4(-1.0,  1.0, 0.5, 1.0),
                               vec4( 1.0,  1.0, 0.5, 1.0));
    vec4 pos = vertices[gl_VertexID];

    gl_Position = pos;
}
