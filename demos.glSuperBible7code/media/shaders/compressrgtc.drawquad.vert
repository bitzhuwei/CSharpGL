#version 430 core

out vec2 uv;

void main(void)
{
    vec2 pos[] = vec2[](vec2(-1.0, -1.0),
                        vec2( 1.0, -1.0),
                        vec2(-1.0,  1.0),
                        vec2( 1.0,  1.0));

    gl_Position = vec4(pos[gl_VertexID], 0.0, 1.0);
    uv = pos[gl_VertexID] * vec2(0.5, -0.5) + vec2(0.5);
}
