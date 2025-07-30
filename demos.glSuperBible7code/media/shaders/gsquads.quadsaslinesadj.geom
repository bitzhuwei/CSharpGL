#version 410 core

layout (lines_adjacency) in;
layout (triangle_strip, max_vertices = 6) out;

in VS_OUT
{
    vec4 color;
} gs_in[4];

out GS_OUT
{
    flat vec4 color[4];
    vec2 uv;
} gs_out;

void main(void)
{
    gl_Position = gl_in[0].gl_Position;
    gs_out.uv = vec2(1.0, 0.0);
    EmitVertex();

    gl_Position = gl_in[1].gl_Position;
    gs_out.uv = vec2(0.0, 0.0);
    EmitVertex();

    gl_Position = gl_in[2].gl_Position;
    gs_out.uv = vec2(0.0, 1.0);

    const int idx0 = 0;
    const int idx1 = 1;
    const int idx2 = 2;
    const int idx3 = 3;

    // We're only writing the output color for the last
    // vertex here because they're flat attributes,
    // and the last vertex is the provoking vertex by default
    gs_out.color[0] = gs_in[idx0].color;
    gs_out.color[1] = gs_in[idx1].color;
    gs_out.color[2] = gs_in[idx2].color;
    gs_out.color[3] = gs_in[idx3].color;
    EmitVertex();

    gl_Position = gl_in[0].gl_Position;
    gs_out.uv = vec2(1.0, 0.0);
    gs_out.color[0] = gs_in[idx0].color;
    gs_out.color[1] = gs_in[idx1].color;
    gs_out.color[2] = gs_in[idx2].color;
    gs_out.color[3] = gs_in[idx3].color;
    EmitVertex();

    gl_Position = gl_in[2].gl_Position;
    gs_out.uv = vec2(0.0, 1.0);
    gs_out.color[0] = gs_in[idx0].color;
    gs_out.color[1] = gs_in[idx1].color;
    gs_out.color[2] = gs_in[idx2].color;
    gs_out.color[3] = gs_in[idx3].color;
    EmitVertex();

    gl_Position = gl_in[3].gl_Position;
    gs_out.uv = vec2(1.0, 1.0);
    gs_out.color[0] = gs_in[idx0].color;
    gs_out.color[1] = gs_in[idx1].color;
    gs_out.color[2] = gs_in[idx2].color;
    gs_out.color[3] = gs_in[idx3].color;
    EmitVertex();

    EndPrimitive();
}
