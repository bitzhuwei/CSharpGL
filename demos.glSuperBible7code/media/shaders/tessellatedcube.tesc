#version 420 core

layout (vertices = 4) out;

/*
in VS_OUT
{
    vec4 color;
} vs_in[];
*/

uniform mat4 mv_matrix;
uniform mat4 proj_matrix;

void main(void)
{
    vec4 pos[4];
    float tf[4];
    float t = 0.0;

    int i;

    if (gl_InvocationID == 0)
    {
        for (i = 0; i < 4; i++)
        {
            pos[i] = proj_matrix * mv_matrix * gl_in[i].gl_Position;
        }

        tf[0] = max(2.0, distance(pos[0].xy / pos[0].w,
                                  pos[1].xy / pos[1].w) * 16.0);
        tf[1] = max(2.0, distance(pos[1].xy / pos[1].w,
                                  pos[3].xy / pos[3].w) * 16.0);
        tf[2] = max(2.0, distance(pos[2].xy / pos[2].w,
                                  pos[3].xy / pos[3].w) * 16.0);
        tf[3] = max(2.0, distance(pos[2].xy / pos[2].w,
                                  pos[0].xy / pos[0].w) * 16.0);
        for (i = 0; i < 4; i++)
        {
            t = max(t, tf[i]);
        }

        gl_TessLevelInner[0] = t;
        gl_TessLevelInner[1] = t;
        gl_TessLevelOuter[0] = tf[0];
        gl_TessLevelOuter[1] = tf[1];
        gl_TessLevelOuter[2] = tf[2];
        gl_TessLevelOuter[3] = tf[3];
    }

    gl_out[gl_InvocationID].gl_Position = gl_in[gl_InvocationID].gl_Position;
}