#version 430 core

void main(void)
{
    const vec4 vertex[] = vec4[] ( vec4(-1.0, -1.0, 0.5, 1.0),
                                   vec4( 1.0, -1.0, 0.5, 1.0),
                                   vec4(-1.0,  1.0, 0.5, 1.0),
                                   vec4( 1.0,  1.0, 0.5, 1.0) );

    gl_Position = vertex[gl_VertexID];
}
