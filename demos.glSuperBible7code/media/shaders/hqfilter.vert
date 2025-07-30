#version 430 core

out VS_OUT
{
    vec2 tc;
} vs_out;

void main(void)
{
    vec2 pos[4] = vec2[4](
                    vec2(-1.0 * 0.9, -1.0 * 0.9),
                    vec2( 1.0 * 0.9, -1.0 * 0.9),
                    vec2(-1.0 * 0.9,  1.0 * 0.9),
                    vec2( 1.0 * 0.9,  1.0 * 0.9));

    vec2 tc[4] = vec2[4](
                    vec2(0.0, 1.0),
                    vec2(1.0, 1.0),
                    vec2(0.0, 0.0),
                    vec2(1.0, 0.0));

    vs_out.tc = tc[gl_VertexID];
    gl_Position = vec4(pos[gl_VertexID], 0.0, 1.0);
}
