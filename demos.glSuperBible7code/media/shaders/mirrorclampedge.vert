#version 430 core

out vec2 uv;

void main(void)
{
    vec2 pos[] = vec2[](vec2(-1.0 * 0.9, -1.0 * 0.9),
                        vec2( 1.0 * 0.9, -1.0 * 0.9),
                        vec2(-1.0 * 0.9,  1.0 * 0.9),
                        vec2( 1.0 * 0.9,  1.0 * 0.9));

    gl_Position = vec4(pos[gl_VertexID], 0.0, 1.0);
    uv = pos[gl_VertexID];
}
