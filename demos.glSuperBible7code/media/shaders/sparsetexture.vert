#version 440 core

out vec2 uv;

void main(void)
{
    vec2 pos = vec2(float(gl_VertexID & 2), float(gl_VertexID * 2 & 2));
    uv = pos * 0.5;
    gl_Position = vec4(pos - vec2(1.0), 0.0, 1.0);
}
