#version 420 core

layout (vertices = 3) out;

uniform float tess_level = 2.7;

void main(void)
{
    if (gl_InvocationID == 0)
    {
        gl_TessLevelInner[0] = tess_level;
        gl_TessLevelOuter[0] = tess_level;
        gl_TessLevelOuter[1] = tess_level;
        gl_TessLevelOuter[2] = tess_level;
    }
    gl_out[gl_InvocationID].gl_Position = gl_in[gl_InvocationID].gl_Position;
}
