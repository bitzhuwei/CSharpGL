#version 430 core

uniform mat4 model_matrix;
uniform mat4 proj_matrix;

layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;

out vec3 vs_worldpos;
out vec3 vs_normal;

void main(void)
{
    vec4 position = proj_matrix * model_matrix * position;
    gl_Position = position;
    vs_worldpos = position.xyz;
    vs_normal = mat3(model_matrix) * normal;
}