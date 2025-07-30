#version 420 core

layout (vertices = 4) out;

/*
in VS_OUT
{
    vec4 color;
} vs_in[];
*/

void main(void)
{
    if (gl_InvocationID == 0)
    {
        gl_TessLevelInner[0] = 4.0;
        gl_TessLevelInner[1] = 4.0;
        gl_TessLevelOuter[0] = 4.0;
        gl_TessLevelOuter[1] = 4.0;
        gl_TessLevelOuter[2] = 4.0;
        gl_TessLevelOuter[3] = 4.0;
    }
    gl_out[gl_InvocationID].gl_Position = gl_in[gl_InvocationID].gl_Position;
}