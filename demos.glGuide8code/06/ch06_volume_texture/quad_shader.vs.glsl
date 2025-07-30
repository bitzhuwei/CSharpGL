#version 330 core

layout (location = 0) in vec2 in_position;
layout (location = 1) in vec2 in_tex_coord;

out vec3 tex_coord;

uniform mat4 tc_rotate;

void main(void)
{
    gl_Position = vec4(in_position * 0.9, 0.5, 1.0);
    tex_coord = (tc_rotate * vec4(in_tex_coord, 0.0, 1.0)).stp;
}