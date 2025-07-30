#version 420 core

in vec4 position;

out VS_OUT
{
    vec4 color;
} vs_out;

struct transform_t
{
    mat4 mv_matrix;
    mat4 proj_matrix;
};

layout (std140, binding = 0) uniform TRANSFORM_BLOCK
{
    transform_t transform[256];
} t;

uniform int transform_index = 0;

void main(void)
{
    gl_Position = t.transform[transform_index].proj_matrix * t.transform[transform_index].mv_matrix * position;
    vs_out.color = position * 2.0 + vec4(0.5, 0.5, 0.5, 0.0);
}
