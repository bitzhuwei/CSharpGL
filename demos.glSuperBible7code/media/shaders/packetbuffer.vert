#version 440 core
layout (binding = 0) uniform BLOCK
{
    vec4 vtx_color[4];
};
out vec4 vs_fs_color;
void main(void)
{
    vs_fs_color = vtx_color[gl_VertexID & 3];
    gl_Position = vec4((gl_VertexID & 2) - 1.0, (gl_VertexID & 1) * 2.0 - 1.0, 0.5, 1.0);
}