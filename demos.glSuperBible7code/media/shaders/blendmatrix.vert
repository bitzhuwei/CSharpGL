#version 410 core

in vec4 position;

out VS_OUT
{
    vec4 color0;
    vec4 color1;
} vs_out;

uniform mat4 mv_matrix;
uniform mat4 proj_matrix;

void main(void)
{
    gl_Position = proj_matrix * mv_matrix * position;
    vs_out.color0 = position * 2.0 + vec4(0.5, 0.5, 0.5, 0.0);
    vs_out.color1 = vec4(0.5, 0.5, 0.5, 0.0) - position * 2.0;
}