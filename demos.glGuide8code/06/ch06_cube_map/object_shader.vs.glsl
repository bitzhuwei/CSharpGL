#version 330 core

layout (location = 0) in vec4 in_position;
layout (location = 1) in vec3 in_normal;

out vec3 vs_fs_normal;
out vec3 vs_fs_position;

uniform mat4 mat_mvp;
uniform mat4 mat_mv;

void main(void)
{
    gl_Position = mat_mvp * in_position;
    vs_fs_normal = mat3(mat_mv) * in_normal;
    vs_fs_position = (mat_mv * in_position).xyz;
}